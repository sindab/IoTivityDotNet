﻿using IotivityDotNet.Interop;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace IotivityNet.OC
{

    public class DiscoverResource
    {
        private string requestUri;
        private OCCallbackData cbData;
        private IntPtr handle;
        private GCHandle gchandle;

        public DiscoverResource(string requestUri = "/oic/res")
        {
            cbData = new OCCallbackData() { cb = OnDiscover };
            this.requestUri = requestUri;
            gchandle = GCHandle.Alloc(cbData);
        }

        ~DiscoverResource()
        {
            Stop();
            gchandle.Free();
        }

        public void Start()
        {
            if (handle != IntPtr.Zero)
                return;

            var ret = OCStack.OCDoResource(out handle, OCMethod.OC_REST_DISCOVER, requestUri, null, IntPtr.Zero, OCConnectivityType.CT_DEFAULT, OCQualityOfService.OC_LOW_QOS, cbData, null, 0);
            if (ret != OCStackResult.OC_STACK_OK)
                throw new Exception(ret.ToString());
        }

        public void Stop()
        {
            if(handle != IntPtr.Zero)
            {
                var ret = OCStack.OCCancel(handle, OCQualityOfService.OC_LOW_QOS, null, 0);
                if (ret != OCStackResult.OC_STACK_OK)
                    throw new Exception(ret.ToString());
                handle = IntPtr.Zero;
            }
        }

        private OCStackApplicationResult OnDiscover(IntPtr context, IntPtr handle, OCClientResponse clientResponse)
        {
            if (clientResponse == null)
            {
                return OCStackApplicationResult.OC_STACK_DELETE_TRANSACTION;
            }
            ResourceDiscovered?.Invoke(this, new ClientResponseEventArgs<OC.DiscoveryPayload>(clientResponse, handle));
            return OCStackApplicationResult.OC_STACK_KEEP_TRANSACTION;
        }

        public event EventHandler<ClientResponseEventArgs<OC.DiscoveryPayload>> ResourceDiscovered;
    }

    public class ClientResponseEventArgs<T> : EventArgs where T : OC.Payload
    {
        internal ClientResponseEventArgs(OCClientResponse clientResponse, IntPtr handle)
        {
            Response = new ClientResponse<T>(clientResponse);
            Handle = handle;
        }

        public ClientResponse<T> Response { get; }

        public IntPtr Handle { get; }
    }

    public class ClientResponse<T> where T : OC.Payload
    {
        private OCClientResponse _response;
        internal ClientResponse(OCClientResponse response)
        {
            _response = response;
        }

        private DeviceAddress _deviceAddress;

        public DeviceAddress DeviceAddress
        {
            get
            {
                return _deviceAddress ?? (_deviceAddress = new DeviceAddress(_response.devAddr));
            }
        }

        private T _payload;

        public T Payload
        {
            get
            {
                if (_payload == null)
                {
                    var pl = Marshal.PtrToStructure(_response.payload, typeof(OCPayload)) as OCPayload;
                    //clientResponse.payload.
                    if (pl.type == OCPayloadType.PAYLOAD_TYPE_DISCOVERY && typeof(T) == typeof(OC.DiscoveryPayload))
                    {
                        _payload = new IotivityNet.OC.DiscoveryPayload(_response.payload) as T;
                    }
                }
                return _payload;

            }
        }

        public string ResourceUri => _response.resourceUri;
    }
}

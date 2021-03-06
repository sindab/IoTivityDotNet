﻿using IotivityDotNet.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IotivityDotNet.Interop
{
    public static class OCPayloadInterop
    {
        [DllImport(Constants.DLL_IMPORT_TARGET)]
        public static extern IntPtr OCDiscoveryPayloadCreate();

        [DllImport(Constants.DLL_IMPORT_TARGET)]
        public static extern UIntPtr OCDiscoveryPayloadGetResourceCount(IntPtr handle);

        [DllImport(Constants.DLL_IMPORT_TARGET, EntryPoint = "OCDiscoveryPayloadGetResource")]
        public static extern IntPtr OCDiscoveryPayloadGetResource(IntPtr handle, UIntPtr index);

        
        [DllImport(Constants.DLL_IMPORT_TARGET)]
        public static extern IntPtr OCPayloadDestroy(IntPtr handle);

        [DllImport(Constants.DLL_IMPORT_TARGET)]
        public static extern IntPtr OCRepPayloadCreate();

        [DllImport(Constants.DLL_IMPORT_TARGET)]
        public static extern IntPtr OCRepPayloadClone(IntPtr payload);

        [DllImport(Constants.DLL_IMPORT_TARGET)]
        public static extern bool OCRepPayloadSetPropDouble(IntPtr payload, string name, double value);
        [DllImport(Constants.DLL_IMPORT_TARGET)]
        public static extern bool OCRepPayloadGetPropDouble(IntPtr payload, string name, out double value);
        [DllImport(Constants.DLL_IMPORT_TARGET)]
        public static extern bool OCRepPayloadSetPropBool(IntPtr payload, string name, bool value);
        [DllImport(Constants.DLL_IMPORT_TARGET)]
        public static extern bool OCRepPayloadGetPropBool(IntPtr payload, string name, out bool value);


        //       void OCRepPayloadAppend(OCRepPayload* parent, OCRepPayload* child);
        //
        //       bool OCRepPayloadSetUri(OCRepPayload* payload, const char* uri);
        //
        //       bool OCRepPayloadAddResourceType(OCRepPayload* payload, const char* resourceType);
        //       bool OCRepPayloadAddInterface(OCRepPayload* payload, const char* iface);
        //       bool OCRepPayloadAddModelVersion(OCRepPayload* payload, const char* dmv);
        //
        //       bool OCRepPayloadAddResourceTypeAsOwner(OCRepPayload* payload, char* resourceType);
        //       bool OCRepPayloadAddInterfaceAsOwner(OCRepPayload* payload, char* iface);
        //
        //       bool OCRepPayloadIsNull(const OCRepPayload* payload, const char* name);
        //       bool OCRepPayloadSetNull(OCRepPayload* payload, const char* name);
        //
        //       bool OCRepPayloadSetPropInt(OCRepPayload* payload, const char* name, int64_t value);
        //       bool OCRepPayloadGetPropInt(const OCRepPayload* payload, const char* name, int64_t* value);
        //
        //       bool OCRepPayloadSetPropDouble(OCRepPayload* payload, const char* name, double value);
        //       bool OCRepPayloadGetPropDouble(const OCRepPayload* payload, const char* name, double* value);
        //
        //       /**
        //        * This function allocates memory for the byte string and sets it in the payload.
        //        *
        //        * @param payload      Pointer to the payload to which byte string needs to be added.
        //        * @param name         Name of the byte string.
        //        * @param value        Byte string and it's length.
        //        *
        //        * @return true on success, false upon failure.
        //        */
        //       bool OCRepPayloadSetPropByteString(OCRepPayload* payload, const char* name, OCByteString value);
        //
        //       /**
        //        * This function sets the byte string in the payload.
        //        *
        //        * @param payload      Pointer to the payload to which byte string needs to be added.
        //        * @param name         Name of the byte string.
        //        * @param value        Byte string and it's length.
        //        *
        //        * @return true on success, false upon failure.
        //        */
        //       bool OCRepPayloadSetPropByteStringAsOwner(OCRepPayload* payload, const char* name,
        //       OCByteString* value);
        //
        //       /**
        //        * This function gets the byte string from the payload.
        //        *
        //        * @param payload      Pointer to the payload from which byte string needs to be retrieved.
        //        * @param name         Name of the byte string.
        //        * @param value        Byte string and it's length.
        //        *
        //        * @note: Caller needs to invoke OCFree on value.bytes after it is finished using the byte string.
        //        *
        //        * @return true on success, false upon failure.
        //        */
        //       bool OCRepPayloadGetPropByteString(const OCRepPayload* payload, const char* name,
        //       OCByteString* value);
        //
        //       bool OCRepPayloadSetPropString(OCRepPayload* payload, const char* name, const char* value);
        //       bool OCRepPayloadSetPropStringAsOwner(OCRepPayload* payload, const char* name, char* value);
        //       bool OCRepPayloadGetPropString(const OCRepPayload* payload, const char* name, char** value);
        //
        //       bool OCRepPayloadSetPropBool(OCRepPayload* payload, const char* name, bool value);
        //       bool OCRepPayloadGetPropBool(const OCRepPayload* payload, const char* name, bool* value);
        //
        //       bool OCRepPayloadSetPropObject(OCRepPayload* payload, const char* name, const OCRepPayload* value);
        //       bool OCRepPayloadSetPropObjectAsOwner(OCRepPayload* payload, const char* name, OCRepPayload* value);
        //       bool OCRepPayloadGetPropObject(const OCRepPayload* payload, const char* name, OCRepPayload** value);
        //
        //       #ifdef __WITH_TLS__
        //       bool OCRepPayloadSetPropPubDataType(OCRepPayload* payload, const char* name, const OicSecKey_t* value);
        //               bool OCRepPayloadSetPropPubDataTypeAsOwner(OCRepPayload* payload, const char* name, const OicSecKey_t* value);
        //               bool OCRepPayloadGetPropPubDataType(const OCRepPayload* payload, const char* name, OicSecKey_t *value);
        //       #endif
        //
        //   /**
        //    * This function allocates memory for the byte string array and sets it in the payload.
        //    *
        //    * @param payload      Pointer to the payload to which byte string array needs to be added.
        //    * @param name         Name of the byte string.
        //    * @param array        Byte string array.
        //    * @param dimensions   Number of byte strings in above array.
        //    *
        //    * @return true on success, false upon failure.
        //    */
        //   bool OCRepPayloadSetByteStringArrayAsOwner(OCRepPayload* payload, const char* name,
        //           OCByteString* array, size_t dimensions[MAX_REP_ARRAY_DEPTH]);
        //
        //       /**
        //        * This function sets the byte string array in the payload.
        //        *
        //        * @param payload      Pointer to the payload to which byte string array needs to be added.
        //        * @param name         Name of the byte string.
        //        * @param array        Byte string array.
        //        * @param dimensions   Number of byte strings in above array.
        //        *
        //        * @return true on success, false upon failure.
        //        */
        //       bool OCRepPayloadSetByteStringArray(OCRepPayload* payload, const char* name,
        //       const OCByteString* array, size_t dimensions[MAX_REP_ARRAY_DEPTH]);
        //
        //       /**
        //        * This function gets the byte string array from the payload.
        //        *
        //        * @param payload      Pointer to the payload from which byte string array needs to be retrieved.
        //        * @param name         Name of the byte string array.
        //        * @param value        Byte string array.
        //        * @param dimensions   Number of byte strings in above array.
        //        *
        //        * @note: Caller needs to invoke OICFree on 'bytes' field of all array elements after it is
        //        *        finished using the byte string array.
        //        *
        //        * @return true on success, false upon failure.
        //        */
        //       bool OCRepPayloadGetByteStringArray(const OCRepPayload* payload, const char* name,
        //               OCByteString** array, size_t dimensions[MAX_REP_ARRAY_DEPTH]);
        //
        //               bool OCRepPayloadSetIntArrayAsOwner(OCRepPayload* payload, const char* name,
        //                       int64_t* array, size_t dimensions[MAX_REP_ARRAY_DEPTH]);
        //               bool OCRepPayloadSetIntArray(OCRepPayload* payload, const char* name,
        //               const int64_t* array, size_t dimensions[MAX_REP_ARRAY_DEPTH]);
        //       bool OCRepPayloadGetIntArray(const OCRepPayload* payload, const char* name,
        //               int64_t** array, size_t dimensions[MAX_REP_ARRAY_DEPTH]);
        //
        //               bool OCRepPayloadSetDoubleArrayAsOwner(OCRepPayload* payload, const char* name,
        //               double* array, size_t dimensions[MAX_REP_ARRAY_DEPTH]);
        //       bool OCRepPayloadSetDoubleArray(OCRepPayload* payload, const char* name,
        //               const double* array, size_t dimensions[MAX_REP_ARRAY_DEPTH]);
        //       bool OCRepPayloadGetDoubleArray(const OCRepPayload* payload, const char* name,
        //               double** array, size_t dimensions[MAX_REP_ARRAY_DEPTH]);
        //
        //       bool OCRepPayloadSetStringArrayAsOwner(OCRepPayload* payload, const char* name,
        //               char** array, size_t dimensions[MAX_REP_ARRAY_DEPTH]);
        //       bool OCRepPayloadSetStringArray(OCRepPayload* payload, const char* name,
        //               const char** array, size_t dimensions[MAX_REP_ARRAY_DEPTH]);
        //       bool OCRepPayloadGetStringArray(const OCRepPayload* payload, const char* name,
        //               char*** array, size_t dimensions[MAX_REP_ARRAY_DEPTH]);
        //
        //       bool OCRepPayloadSetBoolArrayAsOwner(OCRepPayload* payload, const char* name,
        //               bool* array, size_t dimensions[MAX_REP_ARRAY_DEPTH]);
        //       bool OCRepPayloadSetBoolArray(OCRepPayload* payload, const char* name,
        //               const bool* array, size_t dimensions[MAX_REP_ARRAY_DEPTH]);
        //       bool OCRepPayloadGetBoolArray(const OCRepPayload* payload, const char* name,
        //               bool** array, size_t dimensions[MAX_REP_ARRAY_DEPTH]);
        //
        //       bool OCRepPayloadSetPropObjectArrayAsOwner(OCRepPayload* payload, const char* name,
        //               OCRepPayload** array, size_t dimensions[MAX_REP_ARRAY_DEPTH]);
        //               bool OCRepPayloadSetPropObjectArray(OCRepPayload* payload, const char* name,
        //               const OCRepPayload** array, size_t dimensions[MAX_REP_ARRAY_DEPTH]);
        //       bool OCRepPayloadGetPropObjectArray(const OCRepPayload* payload, const char* name,
        //               OCRepPayload*** array, size_t dimensions[MAX_REP_ARRAY_DEPTH]);
        //
        //               void OCRepPayloadDestroy(OCRepPayload* payload);
    }
}

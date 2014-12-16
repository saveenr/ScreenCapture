using System;

namespace ScreenCaptureLib
{
    [global::System.Serializable]
    public class CaptureException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public CaptureException() { }
        public CaptureException(string message) : base(message) { }
        public CaptureException(string message, Exception inner) : base(message, inner) { }
        protected CaptureException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
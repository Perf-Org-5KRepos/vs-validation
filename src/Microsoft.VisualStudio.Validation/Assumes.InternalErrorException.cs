/********************************************************
*                                                        *
*   � Copyright (C) Microsoft. All rights reserved.      *
*                                                        *
*********************************************************/

namespace Microsoft
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
#if NETFRAMEWORK || NETSTANDARD2_0
    using System.Runtime.Serialization;
#endif

    /// <content>
    /// Contains the inner exception thrown by Assumes.
    /// </content>
    public partial class Assumes
    {
        /// <summary>
        /// The exception that is thrown when an internal assumption failed.
        /// </summary>
#if NETFRAMEWORK || NETSTANDARD2_0
        [Serializable]
#endif
        [SuppressMessage("Microsoft.Design", "CA1064:ExceptionsShouldBePublic", Justification = "Internal exceptions should not be caught.")]
        [SuppressMessage("Microsoft.Design", "CA1032:ImplementStandardExceptionConstructors", Justification = "This is an internal exception type and we don't use the recommended ctors.")]
        private sealed class InternalErrorException : Exception
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="InternalErrorException"/> class.
            /// </summary>
            [DebuggerStepThrough]
            public InternalErrorException(string message = null)
                : base(message ?? Strings.InternalExceptionMessage)
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="InternalErrorException"/> class.
            /// </summary>
            [DebuggerStepThrough]
            public InternalErrorException(string message, Exception innerException)
                : base(message ?? Strings.InternalExceptionMessage, innerException)
            {
            }

#if NETFRAMEWORK || NETSTANDARD2_0
            /// <summary>
            /// Initializes a new instance of the <see cref="InternalErrorException"/> class.
            /// </summary>
            [DebuggerStepThrough]
            private InternalErrorException(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
#endif
        }
    }
}

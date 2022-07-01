using System;

namespace Jd.ACES.Common.Exceptions
{
    // Corrupt Key Exception: 
    //     Throw it when received keys are corrupted 
    //     after key verification was performed.
    public class CorruptKeyException : ApplicationException
    {
        public CorruptKeyException(string message) : base(message) { }
    }

    // No Valid Key Exception:
    //     Throw it when KMC Client has no valid key 
    //     for encryption/decryption.
    public class NoValidKeyException : ApplicationException
    {
        public NoValidKeyException(string message) : base(message) { }
    }

    // Service Error Exception:
    //     Throw it when KMC Client receives errors 
    //     from KMS/TMS services.
    public class ServiceErrorException : ApplicationException
    {
        public ServiceErrorException(string message) : base(message) { }
    }

    // Insufficient Salt Length Exception:
    //     Throw it when the salt for calculating 
    //     index is too short.
    public class InsufficientSaltLengthException : ApplicationException
    {
        public InsufficientSaltLengthException(string message) : base(message) { }
    }

    // Invalid Key Permission Exception:
    //     Throw it when the key permission is invalid
    //     for encryption/decryption.
    public class InvalidKeyPermission : ApplicationException
    {
        public InvalidKeyPermission(string message) : base(message) { }
    }

    // Invalid Token Exception:
    //     Throw it when received token is invalid.
    public class InvalidTokenException : ApplicationException
    {
        public InvalidTokenException(string message) : base(message) { }
    }

    // Malformed Exception:
    //     Throw it when received data is malformed.
    public class MalformedException : ApplicationException
    {
        public MalformedException(string message) : base(message) { }
    }

    // Invalid Key Exception:
    //     Throw it when the key is inactive for encryption/decryption.
    public class InvalidKeyException : ApplicationException
    {
        public InvalidKeyException(string message) : base(message) { }
    }

    public class IndexCalculateException : ApplicationException
    {
        public IndexCalculateException(string message) : base(message) { }
    }
}
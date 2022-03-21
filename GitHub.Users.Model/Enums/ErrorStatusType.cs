using System;
using System.Collections.Generic;
using System.Text;

namespace GitHub.Users.Model.Enums
{
    public enum  ErrorStatusType
    {
        NoError = 0,
        NotFound = 1,
        Error = 2,
        NotManaged = 3,
        NullReferenceInput = 4,
        NotValidConversion = 5,
        RowVersionConflict = 6,
        NullRowVersionInput = 7,
        CustomError = 8,
        Exception = 9,
        DuplicateKey = 10,
        InvalidLicenceKey = 11,
        ExecutionError = 12,
        DeleteWithForeignRecords = 13,
        NotAllowedFileExtension = 14,
        FileUploadCountLimit = 15,
        FileUploadSizeLimit = 16,
        NoInternetConnection = 17,
        AccountNotFoundInSystems = 18,
        ValidationError =19,
        InvalidAccessToken = 20,
        AccessTokenExpired = 21
    }
}

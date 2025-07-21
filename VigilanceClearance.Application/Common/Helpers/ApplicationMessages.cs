using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigilanceClearance.Application.Common.Helpers
{
    public static class ApplicationMessages
    {
        public const string RecordNotInserted = "Record not Inserted successfully.";
        public const string RecordNotInsertedError = "Errorr Occurred While  Inserting Record.";
        public const string RecordNotFound = "No record found.";
        public const string InsertSuccess = "Record inserted successfully.";
        public const string UpdateSuccess = "Record updated successfully.";
        public const string DeleteSuccess = "Record deleted successfully.";
        public const string UnexpectedError = "An unexpected error occurred.";
        public const string UnauthorizedAccess = "Unauthorized access.";
        public const string AlreadyExists = "This record already exists.";
        public const string TypeError = "Error";
        public const string TypeWarring = "Warning";
        public const string TypeSuccess = "Success";
        //UpdateMessage

        public const string RecordNotUpdated = " Record Not Updated Successfully";
        public const string RecordUpdated = " Record Updated Successfully";
        public const string RecordUpdatedError = " Errorr Occurred While  Updateding Record ";

        //Data Retrivel
        public const string DataRetrived = "Data retrieved successfully.";
        public const string DataNotRetrived = "Data Not retrieved successfully.";
        public const string DataNotRetrivedError = "Errorr Occurred While  retrieving Record.";
    }
}

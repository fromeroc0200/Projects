using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace BikeStores.Data.Models
{
    public class ProcessResult<T>// where T :class
    {
        public bool HasError { get; set; }
        public string Message { get; set; } = string.Empty; // validation message. It is used as a success message if IsError is false, otherwise it is an error message
        public List<FieldError> FieldErrors { get; set; } = new List<FieldError>();
        public T Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public void AddFieldError(string fieldName, string fieldMessage = null)
        {
            if (string.IsNullOrWhiteSpace(fieldName))     throw new ArgumentException("Empty field name");
            if (string.IsNullOrWhiteSpace(fieldMessage))  throw new ArgumentException("Empty field message");

            // appending error to existing one, if field already contains a message
            var existingFieldError = FieldErrors.FirstOrDefault(e => e.FieldName.Equals(fieldName));

            if (existingFieldError == null)
                FieldErrors.Add(new FieldError { FieldName = fieldName, FieldMessage = fieldMessage });
            else
                existingFieldError.FieldMessage = $"{existingFieldError.FieldMessage}. {fieldMessage}";

            //Set value error
            HasError = true;
        }

        public void AddEmptyFieldError(string fieldName, string contextInfo = null)
        {
            AddFieldError(fieldName, $"No value provided for field. Context info: {contextInfo}");
        }
    }

    public class ProcessResult : ProcessResult<object> { }
}
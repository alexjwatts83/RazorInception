using System.Collections.Generic;

namespace RazorInception.WebUI
{
    public class ApiValidationErrorResponse : ApiResponse
    {
        public ApiValidationErrorResponse() : base(400)
        {
            // TODO
        }
        public IEnumerable<string> Errors { get; set; }
    }
}
namespace TestNSwagNetCoreApp {
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc.Formatters;

    public class RawInputFormatter : InputFormatter
    {
        public RawInputFormatter()
        {
            this.SupportedMediaTypes.Add(new Microsoft.Net.Http.Headers.MediaTypeHeaderValue("text/plain"));
        }

        public override bool CanRead(InputFormatterContext context)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var contentType = context.HttpContext.Request.ContentType;
            if (contentType == "text/plain")
            {
                return true;
            }

            return false;
        }

        /// <summary>Reads an object from the request body.</summary>
        /// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext" />.</param>
        /// <returns>A <see cref="T:System.Threading.Tasks.Task" /> that on completion deserializes the request body.</returns>
        public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
        {
            using var reader = new StreamReader(context.HttpContext.Request.Body);
            var result = new StringModel
            {
                Content = await reader.ReadToEndAsync().ConfigureAwait(false)
            };
            return await InputFormatterResult.SuccessAsync(result).ConfigureAwait(false);
        }
    }
}
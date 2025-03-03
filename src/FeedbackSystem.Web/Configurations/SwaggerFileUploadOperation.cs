// using Microsoft.OpenApi.Models;
// using NSwag;
// using Swashbuckle.AspNetCore.SwaggerGen;
// using OpenApiOperation = Microsoft.OpenApi.Models.OpenApiOperation;
//
// namespace FeedbackSystem.Web.Configurations;
//
// public class SwaggerFileUploadOperation : IOperationFilter
// {
//   public void Apply(OpenApiOperation operation, OperationFilterContext context)
//   {
//     if (operation.RequestBody == null || context.MethodInfo.GetParameters().All(p => p.ParameterType != typeof(IFormFile)))
//       return;
//
//     operation.RequestBody = new OpenApiRequestBody
//     {
//       Content =
//       {
//         ["multipart/form-data"] = new OpenApiMediaType
//         {
//           Schema = new OpenApiSchema
//           {
//             Type = "object",
//             Properties =
//             {
//               ["file"] = new OpenApiSchema
//               {
//                 Type = "string",
//                 Format = "binary"
//               }
//             }
//           }
//         }
//       }
//     };
//   }
//
//   public void Apply(OpenApiOperation operation, OperationFilterContext context)
//   {
//     throw new NotImplementedException();
//   }
// }

using ModelContextProtocol.Server;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;

namespace RestArchitectureTools.Tools
{
    [McpServerToolType]
    public static class RestApiStandardsTool
    {
        private static readonly JsonSerializerOptions DefaultJsonOptions = new()
        {
            WriteIndented = true
        };

        [McpServerTool, Description("Returns a comprehensive list of Intertech REST API design standards and best practices.")]
        public static string GetIntertechRestApiDesignStandards()
        {
            var response = new RestApiStandardsResponse
            {
                Standards = GetStandardsList()
            };
            return JsonSerializer.Serialize(response, DefaultJsonOptions);
        }

        public static List<string> GetStandardsList()
        {
            return
            [
                "Resource paths must use nouns, not verbs. Example: /customers, /order-items (not /getCustomers)",
                "Resource names in URLs must be in kebab-case. Example: /order-items, /user-profiles (not /OrderItems)",
                "Path and query parameters must use camelCase. Example: /customers/{customerId}, ?pageNumber=1&pageSize=10 (not /customers/{CustomerID})",
                "Routes must be meaningful and hierarchical. Example: /customers/{customerId}/orders (not /api/resource)",
                "Endpoints must return appropriate HTTP status codes (200, 201, 204, 400, 401, 403, 404, 500). Example: 204 No Content for delete, 404 Not Found for missing resource.",
                "A maximum of 5 query parameters is allowed per endpoint. Example: /products?category=electronics&sortBy=price&order=asc&pageNumber=1&pageSize=20",
                "Each endpoint must have a one-sentence English summary and each response code must be explained separately. Example: <summary>Creates a new product.</summary> <response code=\"201\">Returns the created product.</response>",
                "Controller-level routes must be explicit and descriptive, not generic or auto-generated. Example: [Route(\"api/products\")] (not [Route(\"api/[controller]\")])",
                "All endpoints must be documented using OpenAPI/Swagger, and documentation must be kept up to date. Example: Provide OpenAPI spec and Swagger UI for all endpoints."
            ];
        }
    }

    public class RestApiStandardsResponse
    {
        public List<string> Standards { get; set; }
    }
}

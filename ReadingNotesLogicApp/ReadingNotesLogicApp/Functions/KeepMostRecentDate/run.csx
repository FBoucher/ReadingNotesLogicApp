#r "Newtonsoft.Json"

using System;
using System.Net;
using Newtonsoft.Json;

public static async Task<object> Run(HttpRequestMessage req, TraceWriter log)
{
    string jsonContent = await req.Content.ReadAsStringAsync();
    dynamic data = JsonConvert.DeserializeObject(jsonContent);

    if (data.lastDate == null || data.newDate == null) {
        return req.CreateResponse(HttpStatusCode.BadRequest, new {
            error = "Please pass lastDate/newDate properties in the input object"
        });
    }

    return req.CreateResponse(HttpStatusCode.OK, new {
        lastestDate = new [] {data.lastDate, data.newDate}.Max()
    });
}

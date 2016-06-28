#r "Newtonsoft.Json"

using System;
using System.Net;
using Newtonsoft.Json;

public static async Task<object> Run(HttpRequestMessage req, TraceWriter log)
{
    string tags;
    string cleanNote;
    
    string jsonContent = await req.Content.ReadAsStringAsync();
    dynamic data = JsonConvert.DeserializeObject(jsonContent);

    if (data.note == null ) {
        return req.CreateResponse(HttpStatusCode.BadRequest, new {
            error = "Please pass note properties in the input object"
        });
    }
    
    log.Info($"Lets get started");
    string note = $"{data.note}";
    int posTag = note.LastIndexOf('[')+1;
    if(posTag > 0){
        log.Info($"pos done");
        tags = note.Substring(posTag, note.Length - posTag-1);
        cleanNote = note.Substring(0,posTag-1);
    }
    else{
        tags = "";
        cleanNote = note;
    }
    return req.CreateResponse(HttpStatusCode.OK, new {
        tags = $"{tags}",
        cleanNote = $"{cleanNote}"
    });
}

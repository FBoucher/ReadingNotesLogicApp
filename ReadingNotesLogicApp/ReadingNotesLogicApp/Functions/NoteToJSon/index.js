module.exports = function (context, data) {
    context.log('Webhook was triggered!');

    // Check if we got first/last properties
    if('Title' in data && 'Author' in data && 'DateAdded' in data && 'Tags' in data && 'Comment' in data && 'Url' in data) {
        context.res = {
            body: { Title: data.Title,
                    Author: data.Author,
                    DateAdded: data.DateAdded ,
                    Tags: data.Tags ,
                    Comment: data.Comment,
                    Url: data.Url  
            }
        };
    }
    else {
        context.res = {
            status: 400,
            body: { error: 'Please pass all note properties in the input object'}
        };
    }

    context.done();
}

module.exports = function (context, data) {
    context.log('Webhook was triggered!');
    
    var num = Math.floor(Math.random()*1000);
    context.log('Number is: ' +num);
    context.res = {
        body: num
    };
    context.done();
}

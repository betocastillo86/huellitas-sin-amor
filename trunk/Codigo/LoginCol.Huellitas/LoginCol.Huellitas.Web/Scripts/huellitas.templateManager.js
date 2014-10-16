var TemplateManager = {

    templates: {},

    get: function (id, callback) {

        // Can we find this template in the cache?
        if (this.templates[id]) {

            // Yes? OK, lets call our callback function and return.
            return callback(templates[id]);
        }

        // Otherwise, lets load it up. We'll build our URL based on the ID passed in.
        var url = '/templates/' + id + '.html',

        // And use a handy jQuery library called Traffic Cop to handle marshalling 
        // requests to the server. This will prevent multiple concurrent requests 
        // for the same resource.
        promise = $.trafficCop(url),
        that = this;

        // Wire up a handler for this request via jQuery's promise API
        promise.done(function (template) {


            var tmp = _.template(template);
            that.templates[id] = tmp;
            callback(tmp);
        });
    }
};
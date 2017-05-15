// sign in:

module.exports = {
    'POST /signin': async (ctx, next) => {
        var
            PSO = ctx.request.body.PSO || '',
            GA = ctx.request.body.GA || '',
            FOA = ctx.request.body.FOA || '',
            SA = ctx.request.body.SA || '',
            subtaskNumber = ctx.request.body.subtaskNumber || '';
        if (PSO === 'on' || subtaskNumber === 'option1') {
            console.log('signin ok!');
            ctx.render('comparison.html', {
                title: 'Comparison 1',
                name: 'Mr Node'
            });
        } else {
            console.log('signin failed!');
            ctx.render('signin-failed.html', {
                title: 'Sign In Failed'
            });
        }
    }
};

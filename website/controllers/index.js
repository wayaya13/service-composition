// index:

module.exports = {
    'GET /': async (ctx, next) => {
        ctx.render('index.html', {
            title: 'Welcome'
        });
    },
    'GET /algorithm.html': async (ctx, next) => {
        ctx.render('algorithm.html', {
            title: 'Algorithm'
        });
    },
    'GET /comparison.html': async (ctx, next) => {
        ctx.render('comparison.html', {
            title: 'Comparison'
        });
    },
    'GET /FOA.html': async (ctx, next) => {
        ctx.render('FOA.html', {
            title: 'Comparison'
        });
    },
    'GET /PSO.html': async (ctx, next) => {
        ctx.render('PSO.html', {
            title: 'Comparison'
        });
    },
    'GET /GA.html': async (ctx, next) => {
        ctx.render('GA.html', {
            title: 'Comparison'
        });
    },
    'GET /SA.html': async (ctx, next) => {
        ctx.render('SA.html', {
            title: 'Comparison'
        });
    }
};

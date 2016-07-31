var cpNavigation = require('./controlpanel.alerts.navigation'),
    cpRoutes = require('./controlpanel.alerts.routes');

module.exports = function (appPath, overrides) {
    overrides = overrides || {};
    overrides.navigation = overrides.navigation || {};

    var settings = [];
    settings.push(cpNavigation(appPath, overrides.navigation));
    settings.push(cpRoutes(appPath));
    return settings;
};
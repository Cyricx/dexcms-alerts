module.exports = function (appPath, overrides) {
    return {
        name: 'ApplicationsControlPanelNavigation',
        dest: appPath + '/applications/controlpanel/config/dexcms.controlpanel.navigation.json',
        options: [
            {
                "title": "Alert",
                "icon": "fa-exclamation-triangle",
                "subLinks": [
                    {
                        "title": "Alerts",
                        "href": overrides.alerts || "alerts"
                    }
                ]
            },
        ]
    };
};
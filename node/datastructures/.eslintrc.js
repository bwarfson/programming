module.exports = {
    "extends": "airbnb-base",
    "plugins": ["jest"],
    "rules": {
        "global-require": 0,
        "eslint linebreak-style": [0, "error", "windows"],
        "linebreak-style": 0,
        "indent": ['error', 4]
    },
    "env": {
        "jest/globals": true
    }
};
// metro.config.js
const path = require('path');

module.exports = {
  transformer: {
    assetPlugins: ['expo-asset/tools/hashAssetFiles'],
  },
  resolver: {
    assetExts: ['db', 'bin', 'cjs', 'mjs'],
  },
};

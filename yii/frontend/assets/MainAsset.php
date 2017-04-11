<?php

namespace frontend\assets;

use yii\web\AssetBundle;

/**
 * Main frontend application asset bundle.
 */
class MainAsset extends AssetBundle
{
    public $basePath = '@webroot';
    public $baseUrl = '@web';

    public $css = [
        'css/bootstrap.min.css',
        // 'css/styles.css?189',
        'css/styles.less',
        'bower_components/font-awesome/css/font-awesome.min.css',
    ];

    public $js = [
        'bower_components/scrollreveal/dist/scrollreveal.min.js',
        'js/landing.js?123',
        'js/countdown.js',
    ];

    public $depends = [
        'yii\web\YiiAsset',
        // 'yii\bootstrap\BootstrapAsset',
        'yii\bootstrap\BootstrapPluginAsset',
        // 'frontend\assets\BowerAsset',
    ];
}
$(function() {
    //alert('start DB server');
    var AlbrusTaskManager = {};
    AlbrusTaskManager.init = {};
    AlbrusTaskManager.init.db = {};

    function init() {
        if (typeof (openDatabase) !== 'undefined') {
            AlbrusTaskManager.init.open();
            AlbrusTaskManager.init.createTable();
            AlbrusTaskManager.init.getTodo();
        }
        else {
            $('#bodyWrapper').html('<h2 class="error_message"> Ваш браузер не поддерживает технологию Web SQL </h2>');
        }
    }
    init();

    // open connetction
    AlbrusTaskManager.init.open = function () {
        AlbrusTaskManager.init.db = openDatabase("AlbrusTaskManager", "1.0", "Albrus Task Manager for Fozzy Group", 1024 * 1024 * 5);
        // название БД, версия, описание, размер
    }

    // CREATE TABLES
    speckyboy.init.createTable = function () {
        var database = speckyboy.init.db;
        database.transaction(function (tx) {
            tx.executeSql("CREATE TABLE IF NOT EXISTS todo (ID INTEGER PRIMARY KEY ASC,todo_item TEXT,due_date VARCHAR)", []);
        });
    }
});
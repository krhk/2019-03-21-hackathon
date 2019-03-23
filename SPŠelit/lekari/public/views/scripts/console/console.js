$(document).ready(function() {

    const commands = {
        standalone: [
        ],
        check: [
            "connection",
            "memory"
        ],
        list: [
            "styles",
            "scripts",
            "errors"
        ],
    };

    function clearInput() {
        $("#console-input").val("");
    }

    function clearOutput() {
        $("#console-out").html("");
    }

    function ouput(content) {
        $("#console-out").append("<p>" + content + "</p>");
    }

    function error(content) {
        $("#console-out").append("<p class='console-error'>" + content + "</p>");
        clearInput();
    }

    $("body").keydown(function(e) {
        if(e.which == 192 && !$("#console-input").is(":focus")) {
            $(".debug-console").stop().slideToggle(300);
            $(".console-show").stop().slideToggle(300);
            $("#console-input").focus();
            e.preventDefault();
        }
    });

    $(".console-close").click(function() {
        $(".debug-console").stop().slideToggle(300);
        $(".console-show").stop().slideDown(300);
    });

    $(".console-show").click(function() {
        $(".console-show").stop().slideToggle(300);
        $(".debug-console").stop().slideDown(300);

        $("#console-input").focus();
    });

    $("#console-form").submit(function(e) {
        e.preventDefault();

        let command = $("#console-input").val();

        if(command == "clear") {
            clearInput();
            clearOutput();
            return true;
        }

        if(command == "reload") {
            location.reload();
            return true;
        }

        if(command == "exit") {
            $(".console-close").click();
            clearInput();
            return true;
        }

        let prefix = command.split(" ")[0];
        let value = command.split(" ")[1];

        if(!commands["standalone"].includes(prefix)) {
            if(commands[prefix] === undefined) {
                error("Invalid command: " + command);
                return false;
            }
    
            if(!commands[prefix].includes(value)) {
                error("Invalid value for command '" + prefix + "': " + value);
                return false;
            }
        }

        else {
            value = "";
        }


        $.ajax({
            url: "",
            method: "POST",
            data: {command_subm:true, prefix, value},
            success: function(response) {
                ouput(response);
            }
        });

        clearInput();
    });

});
let shapeType;
let board = [];

function GetCanvas(id, save,isDecorated) {
    if (shapeType == 'O' && !board.includes(id)) {
        var c = document.getElementById(id);        
        var ctx = c.getContext("2d");
        ctx.beginPath();
        ctx.arc(72, 75, 70, 0, 2 * Math.PI);
        if (isDecorated) {
            ctx.strokeStyle = 'red';
        }
        ctx.stroke();
        board.push(id);
        if (save == true) {
            $.ajax({
                type: "POST",
                url: "/Game/SetValue",
                data: {
                    id: id,
                    value: "O",
                    succes(result) {
                    },
                    error(e) {
                        //alert(e)
                    }
                }
            });
        }
        shapeType = 'X'
    }
    else if (!board.includes(id)) {
        var c = document.getElementById(id);        
        var ctx = c.getContext("2d");
        if (isDecorated) {
            ctx.strokeStyle = 'red';
        }
        ctx.lineWidth = 1;
        ctx.beginPath();
        ctx.moveTo(0, 0);
        ctx.lineTo(c.width /2, c.height);
        ctx.stroke();
        ctx.lineWidth = 1;
        ctx.beginPath();
        ctx.moveTo(c.width / 2, 0);
        ctx.lineTo(0, c.height);
        ctx.stroke();
        board.push(id);
        if (save == true) {
            $.ajax({
                type: "POST",
                url: "/Game/SetValue",
                data: {
                    id: id,
                    value: "X",
                    succes(result) {
                    },
                    error(e) {
                        //alert(e)
                    }
                }
            });
        }
        shapeType = 'O'
    }
}
import Circle from "./Circle";
import Row from "./Row";


export default function Table({xIsNext, players, grid, last_move, onPlay}){
    
    function handleClick(y,x){

        if(grid[y][x] || checkWinner(last_move, grid)){
            return;
        }else{
            let new_grid = grid.slice();

            let y2 = 6
            while(new_grid[y2][x]!=0)
            {
                y2--;
            }
            if(y2>=0)
            {
                new_grid[y2][x] = xIsNext ? 1 : 2;
                
                onPlay(new_grid, [y2,x,xIsNext ? 1 : 2, new Date().toLocaleTimeString()]);
            }
        }   
    }

    const circles = grid.map((line, y) =>{
        
        const row = line.map((i, x) => 
            (<Circle key={x} player={i} onCircleClick={() => handleClick(y,x)}/>)
        );
        
        return (<Row key={y} circles={row}/>) 
    ;});

    const winner = checkWinner(last_move, grid);
    let status;
    if(winner)
    {
        status = "Winner: " + players[winner-1];
    }else{
        status = "Turn Player: " + (xIsNext ? players[0] : players[1]);
    }
    
    return (
        <>
        <div className="status">{status}</div>
        {circles}
        </>
    )
}

function checkWinner(move, current){
    let winner = null;
    if (move){
        const y = move[0];
        const x = move[1];
        const player = move[2];
        
        const directions = [[[-1,-1],[+1,+1]],[[0,-1],[0,+1]],[[+1,-1],[-1,+1]],[[-1,0],[+1,0]]];

        let i = 0;
        while(i<4 && !winner)
        {
            const winner_move = 1 + checkCell(y,x,directions[i][0],current,player) + checkCell(y,x,directions[i][1],current,player);
            if (winner_move >= 4)
            {
                winner = player;
            }else{
                i++;
            }
        }

        
    }

    return winner;
}


function checkCell(y,x,dir,grid,player){
    if(y+dir[0]<7 && y+dir[0] >=0 && x+dir[1]<7 && x+dir[1]>=0)
    {
        if (grid[y+dir[0]][x+dir[1]] == player){
            let r = checkCell(y+dir[0],x+dir[1], dir, grid, player);
            return r+1;
        }else{
            return 0;
        }
    }else return 0;
}
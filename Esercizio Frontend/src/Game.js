import Table from "./components/Table";
import Move from "./components/Move";
import Card from '@mui/material/Card';
import { Grid } from "@mui/material";

import { useState } from "react";

export default function Game() {

    const [historyGrid, setHistoryG] = useState([Array(7).fill().map(()=>Array(7).fill(0))]);
    const [historyMoves, setHistoryM] = useState([Array(4).fill(null)]);
    const [currentMove, setCurrentMove] = useState(0);
    const playerNames = ["Pinco", "Panco"];
    const xIsNext = currentMove%2 === 0;
    const currentGrid = historyGrid[currentMove];
    const last_move = historyMoves[currentMove];

    function handlePlay(nextGrid, nextMove) {
        const nextHistoryG = [...historyGrid.slice(0, currentMove + 1), nextGrid];
        const nextHistoryM = [...historyMoves.slice(0, currentMove + 1), nextMove];
        setHistoryG(nextHistoryG);
        setHistoryM(nextHistoryM);
        setCurrentMove(nextHistoryM.length - 1);
    }

    const moves = historyMoves.slice(1).map((move, n) => {
        return (
        <Card key={n} className="card"><Move n={n+1} y={move[0]} x={move[1]} player={playerNames[move[2]-1]} time={move[3]}/> </Card>
        );
    });
    


  return (
    <div className="game">
      <div className="game-table">
        <Table xIsNext={xIsNext} players={playerNames} grid={currentGrid} last_move={last_move} onPlay={handlePlay}/>
      </div>
      <div className="moves">
        <div className="title">Moves</div>
        <Grid container>
          {moves}
        </Grid>
      </div>
    </div>
  );
}
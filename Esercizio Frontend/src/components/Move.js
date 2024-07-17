import { CardContent } from "@mui/material";
import { Typography } from "@mui/material";

export default function Move({n, y, x, player, time})
{
    return <CardContent>
        <Typography sx={{ fontSize: 14 }} color="text.secondary">
        Move N° : {n}
      </Typography>
      <Typography variant="h5" component="div">
        X : {x}, Y: {y}
      </Typography>
      <Typography sx={{ mb: 0.5 }} color="text.secondary">
        by player {player}
      </Typography>
      <Typography  color="text.secondary">
        at {time}.
        
      </Typography></CardContent>
}
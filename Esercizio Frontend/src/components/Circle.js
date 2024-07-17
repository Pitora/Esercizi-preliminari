export default function Circle({player, onCircleClick})
{
    let color = "";
    if (player == 1){
        color = "p1";
    }else if (player == 2){
        color = "p2";
    }

    return <button className={`circle ${color}`} onClick={onCircleClick}></button>
}
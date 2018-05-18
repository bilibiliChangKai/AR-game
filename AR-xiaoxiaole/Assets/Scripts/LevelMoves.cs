using UnityEngine;
using System.Collections;

public class LevelMoves : Level {

	public int numMoves;

	private int movesUsed = 0;

	// Use this for initialization
	void Start () {
		hud.SetSoldier(currentSoldier);
		hud.SetRemaining (numMoves);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void OnMove ()
	{
		movesUsed++;

		hud.SetRemaining (numMoves - movesUsed);

		if (numMoves - movesUsed == 0) {
            GameEnd();
		}
	}

    public override void OnPieceClicked(GamePiece piece)
    {
        base.OnPieceClicked(piece);
        OnMove();
    }
}

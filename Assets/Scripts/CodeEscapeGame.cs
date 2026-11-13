using UnityEngine;

public class CodeEscapeGame : MonoBehaviour
{
    private const int Width = 11;
    private const int Height = 9;
    private readonly string[] map = {
        "###########",
        "#...K.....#",
        "#..##..#E.#",
        "#......#..#",
        "#..#......#",
        "#..#..K...#",
        "#.....B...#",
        "#P.K......#",
        "###########"
    };
    private char[,] board;
    private int playerX, playerY, collected, totalKeys, steps;
    private bool won;
    private string notice = "Collect all keys, then reach the green exit.";
    private GUIStyle heading, small, tileText, buttonStyle;
    private Texture2D pixel;
    private float lastMove;

    private void Awake()
    {
        pixel = new Texture2D(1, 1);
        pixel.SetPixel(0, 0, Color.white);
        pixel.Apply();
        ResetGame();
    }

    private void ResetGame()
    {
        board = new char[Height, Width];
        collected = 0;
        totalKeys = 0;
        steps = 0;
        won = false;
        notice = "Collect all keys, then reach the green exit.";
        for (int y = 0; y < Height; y++)
            for (int x = 0; x < Width; x++)
            {
                char c = map[y][x];
                if (c == 'P') { playerX = x; playerY = y; c = '.'; }
                if (c == 'K') totalKeys++;
                board[y, x] = c;
            }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) ResetGame();
        if (won || Time.unscaledTime - lastMove < 0.115f) return;
        int dx = 0, dy = 0;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) dy = -1;
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) dy = 1;
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) dx = -1;
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) dx = 1;
        if (dx != 0 || dy != 0) { Move(dx, dy); lastMove = Time.unscaledTime; }
    }

    private void Move(int dx, int dy)
    {
        int x = playerX + dx, y = playerY + dy;
        if (!Inside(x, y) || board[y, x] == '#') return;
        if (board[y, x] == 'B')
        {
            int nx = x + dx, ny = y + dy;
            if (!Inside(nx, ny) || board[ny, nx] != '.') { notice = "The crate cannot move there."; return; }
            board[ny, nx] = 'B';
            board[y, x] = '.';
        }
        if (board[y, x] == 'E')
        {
            if (collected != totalKeys) { notice = "Exit locked! Collect all keys first."; return; }
            won = true;
            notice = "ESCAPED! You solved Code Escape. Press R to play again.";
        }
        if (board[y, x] == 'K')
        {
            collected++;
            board[y, x] = '.';
            notice = collected == totalKeys ? "All keys collected! Go to the exit." : "Key collected!";
        }
        playerX = x;
        playerY = y;
        steps++;
    }

    private bool Inside(int x, int y) { return x >= 0 && x < Width && y >= 0 && y < Height; }

    private void SetupStyles()
    {
        if (heading != null) return;
        heading = new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleCenter, fontSize = 25, fontStyle = FontStyle.Bold };
        heading.normal.textColor = Color.white;
        small = new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleCenter, fontSize = 15, wordWrap = true };
        small.normal.textColor = Color.white;
        tileText = new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleCenter, fontSize = 21, fontStyle = FontStyle.Bold };
        tileText.normal.textColor = Color.white;
        buttonStyle = new GUIStyle(GUI.skin.button) { fontSize = 18, fontStyle = FontStyle.Bold };
    }

    private void Rect(Rect r, Color color)
    {
        Color previous = GUI.color;
        GUI.color = color;
        GUI.DrawTexture(r, pixel);
        GUI.color = previous;
    }

    private void OnGUI()
    {
        SetupStyles();
        float scale = Mathf.Min(Screen.width / 900f, Screen.height / 830f);
        scale = Mathf.Max(scale, 0.3f);
        float ox = (Screen.width - 900 * scale) / 2f;
        float oy = (Screen.height - 830 * scale) / 2f;
        GUI.matrix = Matrix4x4.TRS(new Vector3(ox, oy, 0), Quaternion.identity, new Vector3(scale, scale, 1));
        Rect(new Rect(-ox / scale, -oy / scale, Screen.width / scale, Screen.height / scale), new Color(0.045f, 0.075f, 0.13f));
        GUI.Label(new Rect(0, 20, 900, 42), "CODE ESCAPE", heading);
        GUI.Label(new Rect(0, 65, 900, 30), "Keys: " + collected + "/" + totalKeys + "     Steps: " + steps, small);
        GUI.Label(new Rect(40, 100, 820, 36), notice, small);
        float cell = 56;
        float left = (900 - Width * cell) / 2;
        float top = 148;
        for (int y = 0; y < Height; y++)
            for (int x = 0; x < Width; x++)
            {
                Rect r = new Rect(left + x * cell + 2, top + y * cell + 2, cell - 4, cell - 4);
                char c = board[y, x];
                Color color = new Color(0.15f, 0.26f, 0.39f);
                if (c == '#') color = new Color(0.36f, 0.43f, 0.53f);
                if (c == 'E') color = new Color(0.12f, 0.72f, 0.32f);
                if (c == 'K') color = new Color(0.95f, 0.72f, 0.12f);
                if (c == 'B') color = new Color(0.65f, 0.33f, 0.19f);
                if (x == playerX && y == playerY) color = new Color(0.14f, 0.83f, 0.94f);
                Rect(r, color);
                string symbol = x == playerX && y == playerY ? "YOU" : c == 'K' ? "K" : c == 'E' ? "EXIT" : c == 'B' ? "BOX" : "";
                if (symbol != "") GUI.Label(r, symbol, tileText);
            }
        GUI.Label(new Rect(0, 672, 900, 26), "Move: WASD / Arrow keys or buttons  •  Push the box by walking into it  •  R: Restart", small);
        if (GUI.Button(new Rect(400, 704, 100, 46), "UP", buttonStyle)) Move(0, -1);
        if (GUI.Button(new Rect(280, 755, 100, 46), "LEFT", buttonStyle)) Move(-1, 0);
        if (GUI.Button(new Rect(400, 755, 100, 46), "DOWN", buttonStyle)) Move(0, 1);
        if (GUI.Button(new Rect(520, 755, 100, 46), "RIGHT", buttonStyle)) Move(1, 0);
        if (GUI.Button(new Rect(680, 755, 130, 46), "RESTART", buttonStyle)) ResetGame();
    }
}

using System.IO;
using System.Text;
using TMPro;
using UnityEngine;

public class Test : MonoBehaviour
{
    private const string titleSeparator = "--";
    private const string sectionSeparator = "###";

    public TextMeshProUGUI title;
    public TextMeshProUGUI content;

    private readonly string resourcePath = "Laws/Law_Page";
    public int maxPage;

    private int page;
    public int Page
    {
        get => page;
        set
        {
            page = Mathf.Clamp(value, 1, maxPage);
        }
    }

    private void Start()
    {
        Page = 1;
        DisplayLaw();
    }

    void DisplayLaw()
    {
        string[] lines = ReadResourceFileLines(resourcePath, page);
        ParseAndDisplay(lines);
    }

    private string[] ReadResourceFileLines(string path, int page)
    {
        TextAsset textAsset = Resources.Load<TextAsset>(path + page);
        if (textAsset == null)
        {
            Debug.LogError($"파일이 존재하지 않음. 경로 : {path + page}");
            return new string[0];
        }
        return textAsset.text.Split(new[] { "\r\n", "\n" }, System.StringSplitOptions.None);
    }
    private void ParseAndDisplay(string[] lines)
    {
        if (lines == null || lines.Length == 0)
        {
            Debug.LogWarning("파일이 비어있습니다.");
            return;
        }

        StringBuilder contentBuilder = new StringBuilder();

        for (int i = 0; i < lines.Length; i++)
        {
            switch (lines[i])
            {
                case titleSeparator:
                    if (i + 1 < lines.Length)
                        title.text = lines[++i] + '\n';
                    break;

                case sectionSeparator:
                    if (i + 1 < lines.Length)
                        contentBuilder.AppendLine($"<size=24>{lines[++i]}</size>");
                    break;

                default:
                    contentBuilder.AppendLine(lines[i]);
                    break;
            }
        }

        content.text = contentBuilder.ToString();
    }

    public void NextPage()
    {
        Page++;
        DisplayLaw();
    }
    public void PrePage()
    {
        Page--;
        DisplayLaw();
    }
}

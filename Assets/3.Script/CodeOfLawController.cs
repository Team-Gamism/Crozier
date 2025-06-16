using System.IO;
using System.Text;
using TMPro;
using UnityEngine;

public class CodeOfLawController : MonoBehaviour
{
    private const string titleSeparator = "#";
    private const string sectionSeparator = "###";
    private const string passSeparator = ">>>";

    public TextMeshProUGUI title;
    public TextMeshProUGUI content1;
    public TextMeshProUGUI content2;

    private readonly string resourcesPath = "Laws/Law_Page";
    private readonly int maxPage = 12;

    [SerializeField] GameObject contentObj;
    private int page;
    public int Page
    {
        
        get => page;
        set
        {
            page = Mathf.Clamp(value, 0, maxPage);
            if (page != 0)
                contentObj.SetActive(false);
            DisplayLaw();
        }
    }

    private void OnEnable()
    {
        Page = 0;
        DisplayLaw();
    }

    void DisplayLaw()
    {
        string[] lines = ReadResourceFileLines(resourcesPath, page);
        ParseAndDisplay(lines);
    }

    private string[] ReadResourceFileLines(string path, int page)
    {
        if (page == 0)
        {
            contentObj.SetActive(true);
            return new string[0];
        }

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

        StringBuilder contentBuilder1 = new StringBuilder();
        StringBuilder contentBuilder2 = new StringBuilder();

        bool isNextPage = true ;

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
                        (isNextPage ? contentBuilder1 : contentBuilder2).AppendLine($"<size=24>{lines[++i]}</size>");
                    break;

                case passSeparator:
                    isNextPage = false;
                    break;

                default:
                    (isNextPage ? contentBuilder1 : contentBuilder2).AppendLine(lines[i]);
                    break;
            }
        }

        content1.text = contentBuilder1.ToString();
        content2.text = contentBuilder2.ToString();
    }

    public void NavigatePage(int n)
    {
        Page = n;
    }

    public void NextPage()
    {
        Page++;
       

    }
    public void PrePage()
    {
        Page--;
    }
    public void Hide()
    {
        transform.root.gameObject.SetActive(false);
    }
}

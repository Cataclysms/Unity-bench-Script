using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    [SerializeField]
    private float m_updateInterval = 0.5f;

    private float m_accum;
    private int m_frames;
    private float m_timeleft;
    private float m_fps;
    private float score;
    private float printscore = 0f;
    private float time;
    private GUIStyle style;
    private GUIStyle ministyle;
    private int waru;
    private AnimatorStateInfo stateInfo;

    void Start()
    {
    	style = new GUIStyle();
    	style.fontSize = 30;
    	ministyle = new GUIStyle();
    	ministyle.fontSize = 20;
    }

    private void Update()
    {
        m_timeleft -= Time.deltaTime;
        m_accum += Time.timeScale / Time.deltaTime;
        m_frames++;
        stateInfo = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
        time = stateInfo.normalizedTime;

        if ( 0 < m_timeleft ) return;

        m_fps = m_accum / m_frames;
        m_timeleft = m_updateInterval;
        m_accum = 0;
        m_frames = 0;
    }

    private void OnGUI()
    {
        GUILayout.Label( "フレームレート: " + m_fps.ToString( "f2" ),style);
        score = m_fps / 500;
        printscore = printscore + score;
        GUILayout.Label("ベンチマークスコア :" + printscore.ToString("f2"),style);
        GUILayout.Label("Escキーでいつでも終了",ministyle);
        	if(time >= 1f){
        		m_fps = 0;
        		score = 0;
        		GUILayout.Label("計測完了！",style);
        	}
    }
}

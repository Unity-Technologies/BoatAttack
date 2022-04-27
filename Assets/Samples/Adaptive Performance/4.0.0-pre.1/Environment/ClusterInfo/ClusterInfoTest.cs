using System;
using UnityEngine;
using UnityEngine.AdaptivePerformance;
using UnityEngine.UI;

public class ClusterInfoTest : MonoBehaviour
{
    IAdaptivePerformance ap;
    public Text big;
    public Text med;
    public Text little;
    public Text notSupported;
    public ClusterInfo ClusterInfo;

    void Start()
    {
        ap = Holder.Instance;

        if (ap == null || !ap.Active)
        {
            Debug.Log("[AP ClusterInfo] Adaptive Performance not active.");
            return;
        }
        if (!ap.SupportedFeature(UnityEngine.AdaptivePerformance.Provider.Feature.ClusterInfo))
        {
            notSupported.gameObject.SetActive(true);
            Debug.Log("[AP ClusterInfo] Feature not supported.");
        }

        ClusterInfo = ap.PerformanceStatus.PerformanceMetrics.ClusterInfo;
        AssignClusterInfo(ClusterInfo);
    }

    private void Update()
    {
        if (ap == null || !ap.Active)
            return;

        var clusterInfo = ap.PerformanceStatus.PerformanceMetrics.ClusterInfo;

        if (ClusterInfo.BigCore != clusterInfo.BigCore || ClusterInfo.MediumCore != clusterInfo.MediumCore || ClusterInfo.LittleCore != clusterInfo.LittleCore)
        {
            AssignClusterInfo(clusterInfo);
        }
    }

    void AssignClusterInfo(ClusterInfo clusterInfo)
    {
        big.text = $"Big: {clusterInfo.BigCore}";
        med.text = $"Medium: {clusterInfo.MediumCore}";
        little.text = $"Little: {clusterInfo.LittleCore}";
        Debug.Log($"Cluster Info = Big Cores: {clusterInfo.BigCore} Medium Cores: {clusterInfo.MediumCore} Little Cores: {clusterInfo.LittleCore}");
        ClusterInfo = clusterInfo;
    }
}

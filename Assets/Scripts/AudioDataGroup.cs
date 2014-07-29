using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public enum DataValueType
    {
        Average = 0,
        Median,
        Sum,
        Minimum,
        Maximum
    };

    public enum DataSource
    {
        Raw = 0,
        Spectrum = 1
    };

    class AudioDataGroup : MonoBehaviour 
    {
        //int dataGroupNameCounter = 0;
        //DataSource dataSource = DataSource.Spectrum;

        //int numberSubDataGroups = 5;
        //int frequencyRangeStartIndex = 0;
        //int frequencyRangeEndIndex = 256;
        //float boost = 1.0f;
        //float cutoff = 1.0f;

        //DataContainer[] dataContainers = new DataContainer[(int)DataValueType.Maximum + 1];
        //private Manager manager;

        //public void Start()
        //{
        //    boost = HelperMethods.Validate(boost, 0.001f, 10000.0f, boost);
        //    cutoff = HelperMethods.Validate(cutoff, 0.001f, 10000.0f, cutoff);

        //    for (int i = 0; i < dataContainers.Length; i++)
        //    {
        //        dataContainers[i] = new DataContainer();
        //    }

        //    frequencyRangeEndIndex = HelperMethods.Validate(frequencyRangeEndIndex, 0, (int)manager.windowSize, 0);
        //    frequencyRangeStartIndex = HelperMethods.Validate(frequencyRangeStartIndex, 0, frequencyRangeEndIndex, 0);
        //}
    }
}

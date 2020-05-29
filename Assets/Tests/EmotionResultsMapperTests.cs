using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class EmotionResultsMapperTests
    {
        // A Test behaves as an ordinary method
        [Test]
        public void MapFailResultDoesNotHaveCorrectDimensions()
        {
            var result = EmotionResultsMapper.map(new float[6]);
            Assert.IsTrue(result == "Error: NN output has incorrect dimensions");
        }


        [Test]
        public void MapSuccess()
        {
            float[] neuralNetworkResults =  {
                                            0.1f,
                                            0.2f,
                                            0.3f,
                                            0.4f,
                                            0.5f,
                                            0.6f,
                                            0.7f};

            var result = EmotionResultsMapper.map(neuralNetworkResults);
            string expectedHumanResult = "ANGRY:0.1 DISGUST:0.2 SCARED:0.3 HAPPY:0.4    SAD:0.5 SURPRISED:0.6 NEUTRAL:0.7";

            Assert.AreEqual(expectedHumanResult, result);
        }
    }
}

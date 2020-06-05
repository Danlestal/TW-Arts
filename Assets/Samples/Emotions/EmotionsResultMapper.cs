using TensorFlowLite;

public static class EmotionResultsMapper {

    public static string map(float[] results) {
        if ( results.Length != (int)TensorFlowLite.EmoNet.Emotion.NUMBER_OF_TYPES) {
            return "Error: NN output has incorrect dimensions";
        }

        float maxValue = -1;
        int maxFeelingIndex = -1;
        for (int i = 0; i < results.Length; i++)
        {
            if (results[i] >= maxValue)
            {
                maxValue = results[i];
                maxFeelingIndex = i;
            }
        }

        var emotion = (EmoNet.Emotion) maxFeelingIndex;
        return string.Format("ANGRY: {0} \nDISGUST: {1} \nSCARED: {2} \nHAPPY: {3} \nSAD: {4} \nSURPRISED: {5} \nNEUTRAL: {6}\n\nCURRENT EMOTION:{7}\n ",
                                results[0],
                                results[1],
                                results[2],
                                results[3],
                                results[4],
                                results[5],
                                results[6],
                                emotion.ToString());
    }
    
}
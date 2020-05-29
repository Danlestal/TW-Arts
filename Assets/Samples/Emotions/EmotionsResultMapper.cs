public static class EmotionResultsMapper {

    public static string map(float[] results) {
        if ( results.Length != (int)TensorFlowLite.EmoNet.Emotion.NUMBER_OF_TYPES) {
            return "Error: NN output has incorrect dimensions";
        }

        return string.Format("ANGRY:{0} DISGUST:{1} SCARED:{2} HAPPY:{3}    SAD:{4} SURPRISED:{5} NEUTRAL:{6}",
                                results[0],
                                results[1],
                                results[2],
                                results[3],
                                results[4],
                                results[5],
                                results[6]);
    }
    
}
using UnityEngine;
namespace TensorFlowLite
{

    public class EmoNet : BaseImagePredictor<float>
    {
        public enum Emotion
        {
            ANGRY = 0,
            DISGUST,
            SCARED,
            HAPPY,
            SAD,
            SURPRISED,
            NEUTRAL,
            NUMBER_OF_TYPES
        }

        private float[] emotionsOutput = new float[(int)Emotion.NUMBER_OF_TYPES];
        public EmoNet(string modelPath) : base(modelPath)
        {
        }

        public override void Invoke(Texture inputTex)
        {
            const float OFFSET = 128f;
            const float SCALE = 1f / 128f;
            ToTensor(inputTex, inputs, OFFSET, SCALE);

            interpreter.SetInputTensorData(0, inputs);
            interpreter.Invoke();

            interpreter.GetOutputTensorData(0, emotionsOutput);
        }

        public float[] GetResults()
        {
          return emotionsOutput;
        }
    }

}
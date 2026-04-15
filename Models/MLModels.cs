using Microsoft.ML.Data;

namespace SmartResultSystem
{
    // ============================================================
    // Q#2 - Part (i): Data Model Class for ML Input and Output
    // ============================================================

    // Input features for ML model
    public class StudentData
    {
        [LoadColumn(0)]
        public float Marks { get; set; }         // Feature 1

        [LoadColumn(1)]
        public float Attendance { get; set; }    // Feature 2

        [LoadColumn(2)]
        public float Assignments { get; set; }   // Feature 3

        [LoadColumn(3)]
        [ColumnName("Label")]
        public bool PassFail { get; set; }       // Prediction Label
    }

    // Output/Prediction result from ML model
    public class StudentPrediction
    {
        [ColumnName("PredictedLabel")]
        public bool PredictedPassFail { get; set; }

        public float Probability { get; set; }

        public float Score { get; set; }
    }
}

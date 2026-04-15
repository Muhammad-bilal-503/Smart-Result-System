using System.Collections.Generic;
using Microsoft.ML;

namespace SmartResultSystem
{
    // ============================================================
    // Q#2 - Part (ii): ML.NET Model - Pass/Fail Prediction
    // Simple Binary Classification using SDCA Logistic Regression
    // ============================================================
    public class MLModelTrainer
    {
        private MLContext mlContext;
        private ITransformer trainedModel;
        private PredictionEngine<StudentData, StudentPrediction> predictionEngine;

        public MLModelTrainer()
        {
            mlContext = new MLContext(seed: 0);
            TrainModel();
        }

        private void TrainModel()
        {
            // Training dataset
            var trainingData = new List<StudentData>
            {
                new StudentData { Marks = 85, Attendance = 90, Assignments = 80, PassFail = true },
                new StudentData { Marks = 75, Attendance = 85, Assignments = 70, PassFail = true },
                new StudentData { Marks = 65, Attendance = 75, Assignments = 60, PassFail = true },
                new StudentData { Marks = 55, Attendance = 70, Assignments = 50, PassFail = true },
                new StudentData { Marks = 50, Attendance = 65, Assignments = 45, PassFail = true },
                new StudentData { Marks = 45, Attendance = 60, Assignments = 40, PassFail = false },
                new StudentData { Marks = 35, Attendance = 50, Assignments = 30, PassFail = false },
                new StudentData { Marks = 25, Attendance = 40, Assignments = 20, PassFail = false },
                new StudentData { Marks = 20, Attendance = 30, Assignments = 15, PassFail = false },
                new StudentData { Marks = 10, Attendance = 20, Assignments = 10, PassFail = false },
                new StudentData { Marks = 90, Attendance = 95, Assignments = 88, PassFail = true },
                new StudentData { Marks = 40, Attendance = 55, Assignments = 35, PassFail = false },
            };

            // Load data
            var dataView = mlContext.Data.LoadFromEnumerable(trainingData);

            // Build ML Pipeline
            var pipeline = mlContext.Transforms
                .Concatenate("Features", "Marks", "Attendance", "Assignments")
                .Append(mlContext.BinaryClassification.Trainers
                    .SdcaLogisticRegression(labelColumnName: "Label", featureColumnName: "Features"));

            // Train model
            trainedModel = pipeline.Fit(dataView);

            // Create prediction engine
            predictionEngine = mlContext.Model
                .CreatePredictionEngine<StudentData, StudentPrediction>(trainedModel);
        }

        // Predict Pass/Fail
        public StudentPrediction Predict(float marks, float attendance, float assignments)
        {
            var input = new StudentData
            {
                Marks = marks,
                Attendance = attendance,
                Assignments = assignments
            };
            return predictionEngine.Predict(input);
        }
    }
}

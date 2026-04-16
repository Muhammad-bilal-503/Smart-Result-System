#  Smart Student Result Prediction System

<div align="center">

![C#](https://img.shields.io/badge/C%23-.NET%208.0-blue?style=for-the-badge&logo=csharp)
![ML.NET](https://img.shields.io/badge/ML.NET-3.0.0-purple?style=for-the-badge)
![Windows Forms](https://img.shields.io/badge/Windows-Forms-0078D6?style=for-the-badge&logo=windows)
![Docker](https://img.shields.io/badge/Docker-Containerized-2496ED?style=for-the-badge&logo=docker)

**Institute of Space Technology — KICSIT Campus, Kahuta**  
**Course: Advance Programming (VP) Lab | Mid Term Spring 2026**  
**Instructor: Mr. Uzair Hassan | Semester: BSCS-VI**

</div>

---

##  Table of Contents

- [Overview](#overview)
- [Project Structure](#project-structure)
- [Question 1 — OOP System](#question-1--oop-system)
- [Question 2 — ML.NET + Docker](#question-2--mlnet--docker)
- [How to Run](#how-to-run)
- [Docker Deployment](#docker-deployment)

---

##  Overview

This project is a **Smart Student Result Prediction System** built in C# using Windows Forms and ML.NET. It was developed as a Mid Term Lab exam submission and covers two major questions:

| Question | Topic | Marks |
|----------|-------|-------|
| Q1 | OOP System — Console + Windows Forms | 20 |
| Q2 | ML.NET Integration + Docker Deployment | 20 |
| **Total** | | **40** |

---

##  Project Structure

```
SmartResultSystem/
│
├── 📄 SmartResultSystem.csproj     ← Open this in Visual Studio
├── 📄 Program.cs                   ← Application entry point
├── 📄 Dockerfile                   ← Docker deployment (Q2)
├── 📄 README.md                    ← Project documentation
│
├── 📂 Models/
│   ├── StudentModels.cs            ← Person & Student OOP classes (Q1)
│   └── MLModels.cs                 ← StudentData & StudentPrediction (Q2)
│
├── 📂 ML/
│   └── MLModelTrainer.cs           ← ML.NET model training & prediction (Q2)
│
└── 📂 Forms/
    ├── MainForm.cs                 ← Main UI with 2 tabs — Q1 & Q2
    └── AllStudentsForm.cs          ← Second form — all student records (Q1)
```

---

##  Question 1 — OOP System

###  OOP Concepts Implemented

#### 1. Person Class (Base Class)
```csharp
public class Person
{
    public string Name { get; set; }   // Encapsulation
    public int Age { get; set; }
    public string ID { get; set; }

    public Person(string name, int age, string id) { ... }  // Constructor

    public virtual string CalculateResult(double marks) { ... }  // Polymorphism
}
```

#### 2. Student Class (Derived Class — Inheritance)
```csharp
public class Student : Person   // Inheritance
{
    public double Marks { get; set; }     // Encapsulation
    public string Semester { get; set; }
    public string Department { get; set; }

    public Student(string name, int age, string id, double marks, string semester, string dept)
        : base(name, age, id) { ... }    // Calling base constructor

    public override string CalculateResult(double marks) { ... }  // Polymorphism
}
```

#### 3. Grade Logic
| Marks | Result |
|-------|--------|
| 80+ | A Grade — Distinction |
| 70+ | B Grade — Merit |
| 60+ | C Grade — Pass |
| 50+ | D Grade — Pass |
| Below 50 | F Grade — Fail |

###  Windows Forms Interface
- **Labels + TextBoxes** for student data entry
- **4 Buttons** with Event Handling:
  - `Add Student` — creates Student object, saves to list
  - `Show Result` — displays predicted grade on form
  - `View All Students` — opens second form
  - `Clear` — resets all fields

###  Multiple Form Interaction
```csharp
// Data passed from MainForm to AllStudentsForm
AllStudentsForm allForm = new AllStudentsForm(studentList);
allForm.Show();
```

---

##  Question 2 — ML.NET + Docker

###  Data Model Classes
```csharp
public class StudentData
{
    public float Marks { get; set; }        // Feature 1
    public float Attendance { get; set; }   // Feature 2
    public float Assignments { get; set; }  // Feature 3

    [ColumnName("Label")]
    public bool PassFail { get; set; }      // Prediction Label
}

public class StudentPrediction
{
    [ColumnName("PredictedLabel")]
    public bool PredictedPassFail { get; set; }
    public float Probability { get; set; }
}
```

###  ML.NET Pipeline
```csharp
var pipeline = mlContext.Transforms
    .Concatenate("Features", "Marks", "Attendance", "Assignments")
    .Append(mlContext.BinaryClassification.Trainers
        .SdcaLogisticRegression(labelColumnName: "Label", featureColumnName: "Features"));

trainedModel = pipeline.Fit(dataView);
```

- **Algorithm:** SDCA Logistic Regression (Binary Classification)
- **Input:** Marks, Attendance, Assignments
- **Output:** Pass / Fail + Confidence %

###  Dockerfile
```dockerfile
# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY *.csproj ./
RUN dotnet restore
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "SmartResultSystem.dll"]
```

---

##  How to Run

### Prerequisites
- Visual Studio 2022
- .NET 8.0 SDK
- NuGet Package: `Microsoft.ML 3.0.0` *(installs automatically)*

### Steps
```
1. Extract the zip file
2. Double-click SmartResultSystem.csproj
3. Visual Studio will open and restore packages automatically
4. Press F5 to run
```

>  **Note:** If you see a platform error, go to:
> `Build → Configuration Manager → Change platform to x64`

---

##  Docker Deployment

```bash
# Step 1: Build the Docker image
docker build -t smart-result-app .

# Step 2: Run the container
docker run -d -p 8080:8080 --name smart-result-container smart-result-app

# Step 3: Verify application is running
docker ps

# Step 4: View logs
docker logs smart-result-container

# Step 5: Stop the container
docker stop smart-result-container

# Step 6: Remove the container
docker rm smart-result-container
```

---

##  Developer

| Field | Details |
|-------|---------|
| **Name** | Muhammad Bilal |
| **GitHub** | [@Muhammad-bilal-503](https://github.com/Muhammad-bilal-503) |
| **Institute** | IST — KICSIT Campus, Kahuta |
| **Semester** | BSCS-VI |
| **Course** | Advance Programming (VP) Lab |

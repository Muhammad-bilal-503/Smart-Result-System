# Smart Student Result Prediction System
**Institute of Space Technology - KICSIT Campus, Kahuta**
**Course: Advance Programming (VP) Lab | Mid Term Spring 2026**
**Instructor: Mr. Uzair Hassan | Semester: BSCS-VI**

---

## Project Structure

```
SmartResultSystem/
│
├── SmartResultSystem.csproj     ← Project file (open this in Visual Studio)
├── Program.cs                   ← Entry point
├── Dockerfile                   ← Docker deployment (Q2)
│
├── Models/
│   ├── StudentModels.cs         ← Person & Student class (Q1 OOP)
│   └── MLModels.cs              ← StudentData & StudentPrediction (Q2 ML)
│
├── ML/
│   └── MLModelTrainer.cs        ← ML.NET model training & prediction (Q2)
│
└── Forms/
    ├── MainForm.cs              ← Main Windows Form with 2 tabs (Q1 + Q2)
    └── AllStudentsForm.cs       ← Second form - all student records (Q1 Part v)
```

---

## How to Run (Visual Studio)

1. Open **Visual Studio 2022**
2. Click **"Open a project or solution"**
3. Navigate to this folder and select **`SmartResultSystem.csproj`**
4. Wait for NuGet packages to restore automatically
5. Press **F5** to run

> **Note:** If you see a platform error, go to:
> Build → Configuration Manager → Change platform to **x64**

---

## Q#1 - OOP System (Tab 1)

### OOP Concepts Used:
- **Encapsulation** - Properties with get/set in Person and Student class
- **Inheritance** - Student inherits from Person class
- **Polymorphism** - CalculateResult() method overridden in Student class

### Grade Logic:
| Marks | Result |
|-------|--------|
| 80+   | A Grade - Distinction |
| 70+   | B Grade - Merit |
| 60+   | C Grade - Pass |
| 50+   | D Grade - Pass |
| <50   | F Grade - Fail |

### Features:
- Add Student with full details
- Show predicted result on form
- View all students in second form (Multiple Form Interaction)

---

## Q#2 - ML.NET Prediction (Tab 2)

### ML Model:
- **Algorithm:** SDCA Logistic Regression (Binary Classification)
- **Input Features:** Marks, Attendance, Assignments
- **Output:** Pass / Fail + Confidence %

### Docker Deployment:
```bash
# Build Docker image
docker build -t smart-result-app .

# Run container
docker run -d -p 8080:8080 --name smart-result-container smart-result-app

# Verify execution
docker ps
docker logs smart-result-container

# Stop container
docker stop smart-result-container
```

---

## NuGet Package Required
- `Microsoft.ML` (Version 3.0.0) — installs automatically via .csproj

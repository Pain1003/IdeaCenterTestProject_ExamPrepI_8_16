pipeline {
    agent any

    stages {
        stage('Checkout code') {
            //checkout the repository
            steps {
                git branch: 'main', url: 'https://github.com/Pain1003/IdeaCenterTestProject_ExamPrepI_8_16'
            }
        }
        stage('Set up .Net Core') {
            //install dot net
            steps {
                bat '''
                Echo Downloading .Net 8 SDK
                curl -l -o dotnet-sdk-8.0.401-win-x86.exe https://download.visualstudio.microsoft.com/download/pr/523db424-b1cc-425d-97f5-bd0e9b0c7440/f04171a6d597780662d809107a13f44e/dotnet-sdk-8.0.401-win-x86.exe
                echo Installing dotnet-sdk-8.0.401-win-x86.exe
                dotnet-sdk-8.0.401-win-x86 /quiet /norestart
                '''
            }
        }
        stage('Restore dependencies') {
            //install dependencies
            steps {
                bat 'dotnet restore 17.Exam-Prep-I.sln'
            }
        }
        stage('Build') {
            //build
            steps {
                bat 'dotnet build 17.Exam-Prep-I.sln --configuration Release'
            }
        }
        stage('Run Tests') {
            //run tests
            steps {
                bat 'dotnet test 17.Exam-Prep-I/17.Exam-Prep-I.csproj --logger "trx;LogFileName=TestResults.trx"'
            }
        }
    }

    post {
        always {
            archiveArtifacts artifacts: '**/TestResults/*.trx', allowEmptyArchive: true
            step ([
                $class: 'MSTestPublisher',
                TestResultsFile: '**/TestResults/*.trx'
            ])
        }
    }
}
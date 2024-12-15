#!/bin/bash

# Check if an argument is provided
if [ -z "$1" ]; then
    echo "Usage: $0 <day_number>"
    exit 1
fi

DAY="day_$1"
PROJECT_PATH="$DAY/$DAY.csproj"
PROGRAM_PATH="$DAY/Program.cs"
TEMPLATE_PATH="Template/Program.cs.Template"
CSPROJECT_TEMPLATE="Template/Day.csproj.Template"

# Create the directory and project
mkdir -p "$DAY"
dotnet new console -o "$DAY" --name "$DAY"
touch "$DAY/input.txt"

# Copy the .csproj template to the project directory
sed "s/{DAY_NUMBER}/$1/g" "$CSPROJECT_TEMPLATE" > "$PROJECT_PATH"

# Restore the project
dotnet restore "$PROJECT_PATH"

# Update the solution file
dotnet sln AdventOfCode.sln add "$PROJECT_PATH"

# Use the template to create Program.cs with the correct namespace
sed "s/{DAY_NUMBER}/$1/g" "$TEMPLATE_PATH" > "$PROGRAM_PATH"

echo "Project for Day $1 created, Program.cs updated using the template, and added to the solution."

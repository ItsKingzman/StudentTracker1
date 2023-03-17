import React, { Component } from "react";
import { StudentReport } from "../Models/StudentReport";
import { Input, NumericTextBox } from "@progress/kendo-react-inputs";
import { records, populateStudentReports } from './DataHelper';
import "../custom.css";

// This is a form for creating student reports. It has three main components: an Input, a NumericTextBox, and a Submit button.
// The Input components accept name and course information from the user, while the NumericTextBox component accepts grade input from the user.
// The handleFieldChange event handler is used to update the component state based on the user’s input.
// Lastly, the onSubmit event handler is used to prevent a default form submission, and to post the record to an API.

// The CreateStudentReports component is a class component that takes a
// callback function onSubmit as a prop. The component's state is set to include the fields of name, course, and grade.
class CreateStudentReports extends Component<
  { onSubmit: (ev: any) => void },
  {
    fields: {
      name: string;
      course: string;
      grade: number;
    };
  }
> {
  constructor(props) {
    super(props);
    this.state = {
      fields: {
        name: "",
        course: "",
        grade: 0,
      },
    };
  }

// The handleFieldChange method updates the component's state
// with the value of the respective field when it is changed.
  handleFieldChange = (ev) => {
    const { name, value } = ev.target;
    const fields = this.state["fields"];
    fields[name] = value;
    this.setState({ fields });
    console.log(this.state.fields[name]);
  };

  // The onSubmit method is called when the submit button is pressed.
  // This method prevents the default event from happening and creates a StudentReport from the component's fields.
  // If all the fields are not filled in, an alert pops up. If all of the fields are filled in, then the postRecord
  // function is called.
  onSubmit = (ev) => {
    ev.preventDefault();
    const studentReport: StudentReport = {
      name: this.state["fields"].name,
      course: this.state["fields"].course,
      grade: this.state.fields.grade,
    };
    if (studentReport.name && studentReport.course && studentReport.grade) {
      this.postRecord();
    } else {
      alert("Please fill in all required fields");
    }
  };

// The postRecord async function makes a POST request to the api/studentreport endpoint.
// When the request is finished, the populateStudentReports function is called.
  postRecord = async() => {
    const opts = {
      method: "POST",
      body: JSON.stringify(this.state.fields),
      headers: {
        Accept: "application/json, text/plain",
        "Content-Type": "application/json;charset=UTF-8",
      },
    };

    fetch("api/studentreport", opts).then(async (res) => {
      await populateStudentReports();
    });
  };

// Finally, render returns a form with three inputs and a submit button.
// The handleFieldChange function is called when the inputs are changed and the onSubmit function is called
// when the submit button is pressed.
  render() {
    return (
      <div>
        <form className="form" onSubmit={this.onSubmit}>
          <Input
            name="name"
            onChange={this.handleFieldChange}
            className="input"
            label="Name"
          />
          <Input
            name="course"
            onChange={this.handleFieldChange}
            className="input"
            label="Course"
          />
          <NumericTextBox
            name="grade"
            onChange={this.handleFieldChange}
            className="input"
            label="Grade"
          />
          <button className="submit" type="submit">
            Submit
          </button>
        </form>
      </div>
    );
  }
}

export default CreateStudentReports;

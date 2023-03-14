import React, { Component } from "react";
import { StudentReport } from "../Models/StudentReport";
import { Input, NumericTextBox } from "@progress/kendo-react-inputs";
import { records, populateStudentReports } from './DataHelper';
import "../custom.css";

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

  handleFieldChange = (ev) => {
    const { name, value } = ev.target;
    const fields = this.state["fields"];
    fields[name] = value;
    this.setState({ fields });
    console.log(this.state.fields[name]);
  };

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
      // res.json().then((data) => {
      //   console.log("RESPONSE: ", data);
      // });
      await populateStudentReports();
    });
  };

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

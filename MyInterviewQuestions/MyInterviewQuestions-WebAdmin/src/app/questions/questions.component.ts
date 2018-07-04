import { Component, OnInit } from '@angular/core';
import { QuestionService } from '../question.service';
import { Question } from '../question';

@Component({
  selector: 'app-questions',
  templateUrl: './questions.component.html',
  styleUrls: ['./questions.component.css']
})
export class QuestionsComponent implements OnInit {

  questions: Question[];

  constructor(private questionService: QuestionService) { }

  ngOnInit() {
  }

  add(title: string, bodyText: string): void {
    title = title.trim();
    bodyText = bodyText.trim();

    if(!title){return;}

    this.questionService.addQuestion({title,bodyText} as Question)
      .subscribe( question => { this.questions.push(question);
      });
  }
}

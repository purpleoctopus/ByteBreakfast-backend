import {Component, OnInit} from '@angular/core';
import { Course } from '../../../models/course.model';
import { Observable } from 'rxjs';
import { AsyncPipe } from '@angular/common';
import {CourseService} from '../../../services/course.service';
import {ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-course-detail',
  imports: [AsyncPipe],
  templateUrl: './course-detail.component.html',
  styleUrl: './course-detail.component.scss'
})
export class CourseDetailComponent implements OnInit {
  protected course$: Observable<Course> = new Observable<Course>();

  constructor(private courseService: CourseService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    const courseId = this.route.snapshot.paramMap.get('id');
    if(courseId) {
      this.course$ = this.courseService.getCourseById(courseId);
    }
  }
}

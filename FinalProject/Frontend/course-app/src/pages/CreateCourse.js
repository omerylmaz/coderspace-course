import React, { useEffect, useState } from 'react';
import { Formik, Form, Field, ErrorMessage } from 'formik';
import * as Yup from 'yup';
import alertify from 'alertifyjs';
import 'alertifyjs/build/css/alertify.css';
import courseService from '../services/courseService';
import categoryService from '../services/categoryService';
import { useNavigate } from 'react-router-dom';

export default function CreateCourse() {
  const [categories, setCategories] = useState([]);
  const navigate = useNavigate();

  useEffect(() => {
    const fetchCategories = async () => {
      try {
        const data = await categoryService.getAllCategories();
        setCategories(data.categories);
      } catch (error) {
        // alertify.error(error.message);
      }
    };

    fetchCategories();
  }, []);

  const initialValues = {
    name: '',
    title: '',
    categoryId: '',
    description: '',
    price: '',
    imageUrl: '',
  };

  const validationSchema = Yup.object({
    title: Yup.string().required('Required'),
    name: Yup.string().required('Required'),
    description: Yup.string().required('Required'),
    price: Yup.number()
      .required('Required')
      .positive('Must be positive')
      .typeError('Must be a number'),
    imageUrl: Yup.string().required('Required'),
  });

  const handleSubmit = async (values, { setSubmitting, resetForm }) => {
    try {
      await courseService.createCourse(values);
      alertify.success('Course created successfully');
      navigate('/teacher');
    } catch (err) {
    } finally {
      setSubmitting(false);
    }
  };

  return (
    <div className="container mt-5">
      <div className="card shadow-lg">
        <div className="card-header bg-primary text-white">
          <h2 className="text-center mb-0">Create New Course</h2>
        </div>
        <div className="card-body">
          <Formik initialValues={initialValues} validationSchema={validationSchema} onSubmit={handleSubmit}>
            {({ isSubmitting }) => (
              <Form>
                <div className="mb-4 position-relative">
                  <label className="form-label">Course Title</label>
                  <Field type="text" name="title" className="form-control" placeholder="Enter course title" />
                  <ErrorMessage
                    name="title"
                    component="div"
                    className="text-danger position-absolute small"
                    style={{ top: "100%", paddingTop: "5px" }}
                  />
                </div>

                <div className="mb-4 position-relative">
                  <label className="form-label">Course Name</label>
                  <Field type="text" name="name" className="form-control" placeholder="Enter course name" />
                  <ErrorMessage
                    name="name"
                    component="div"
                    className="text-danger position-absolute small"
                    style={{ top: "100%", paddingTop: "5px" }}
                  />
                </div>

                <div className="mb-4 position-relative">
                  <label className="form-label">Description</label>
                  <Field
                    as="textarea"
                    name="description"
                    className="form-control"
                    placeholder="Enter course description"
                    rows="4"
                  />
                  <ErrorMessage
                    name="description"
                    component="div"
                    className="text-danger position-absolute small"
                    style={{ top: "100%", paddingTop: "5px" }}
                  />
                </div>

                <div className="mb-4 position-relative">
                  <label className="form-label">Price</label>
                  <Field type="number" name="price" className="form-control" placeholder="Enter course price" />
                  <ErrorMessage
                    name="price"
                    component="div"
                    className="text-danger position-absolute small"
                    style={{ top: "100%", paddingTop: "5px" }}
                  />
                </div>

                <div className="mb-4 position-relative">
                  <label className="form-label">Category</label>
                  <Field as="select" name="categoryId" className="form-control">
                    <option value="" label="Select a category" />
                    {categories.map((cat) => (
                      <option key={cat.id} value={cat.id}>
                        {cat.name}
                      </option>
                    ))}
                  </Field>
                  <ErrorMessage
                    name="category"
                    component="div"
                    className="text-danger position-absolute small"
                    style={{ top: "100%", paddingTop: "5px" }}
                  />
                </div>

                <div className="mb-4 position-relative">
                  <label className="form-label">Image URL</label>
                  <Field
                    type="text"
                    name="imageUrl"
                    className="form-control"
                    placeholder="Enter image URL"
                  />
                  <ErrorMessage
                    name="imageUrl"
                    component="div"
                    className="text-danger position-absolute small"
                    style={{ top: "100%", paddingTop: "5px" }}
                  />
                </div>

                <button type="submit" className="btn btn-primary w-100" disabled={isSubmitting}>
                  {isSubmitting ? 'Creating...' : 'Create Course'}
                </button>
              </Form>
            )}
          </Formik>
        </div>
      </div>
    </div>
  );
}

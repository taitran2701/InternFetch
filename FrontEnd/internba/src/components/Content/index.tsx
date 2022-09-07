import React, { Fragment, useEffect, useState } from "react";
import Card from "./Card.module.scss";
import News from "./News.module.scss";
import AddStatus from "../AddStatus";
import PostUser from "../PostUser";
import PostEmotion from "../PostEmotion";
import PostAction from "../PostAction";
import PostComment from "../PostComment";
import AddComment from "../AddComment";

export default function Content() {
  interface IPost {
    id: string;
    content: string;
    userId: string;
  }

  const [show, setShow] = useState(false);
  const [posts, setPosts] = useState([]);
  const [user, setUser] = useState<{ userId: string }>();

  useEffect(() => {
    fetch("https://localhost:7076/api/Posts")
      .then((response) => response.json())
      .then((data) => {
        console.log(data);
        setPosts(data);
        // const user = localStorage.getItem("user");
        // if (user) {
        //   setUser(JSON.parse(user));
        // }
      })
      .catch((err) => {
        ("");
        console.log(err.message);
      });
  }, []);

  //Delete
  const deletePost = async (id: string) => {
    await fetch(`https://localhost:7076/api/Posts/${id}`, {
      method: "DELETE",
    }).then((response) => {
      if (response.status === 200) {
        setPosts(
          posts.filter((post: IPost) => {
            return post.id !== id;
          })
        );
      } else {
        return;
      }
    });
  };
  return (
    <React.Fragment>
      <div>
        <div className={Card.newsCard}>
          <AddStatus />
        </div>

        <div className={Card.newsCard}>
          <PostUser />
          {posts.map((post: IPost) => {
            return (
              <div>
                <div className={News.newsDescription}>{post.content}</div>
                <div className={News.newsImage}>
                  {/* <p>{user?.userId}</p> */}
                </div>
                <div className={News.newsEmotion}>
                  <PostEmotion />
                </div>

                <div className={News.feedAction}>
                  <PostAction />
                </div>

                <div className={News.feedComment}>
                  <PostComment />
                  <div className={News.addComment}>
                    <AddComment />
                  </div>
                </div>
                <div className={Card.deleteButton}>
                  <div
                    className="delete-btn"
                    onClick={() => deletePost(post.id)}
                  >
                    Delete
                  </div>
                </div>
              </div>
            );
          })}
        </div>

        <div className={Card.newsCard}>
          <PostUser />
          <div className={News.newsDescription}>
            Let create our first social web
          </div>
          <div className={News.newsImage}>
            <img
              src="https://unica.vn/media/imagesck/1604553244_Social-network-la-gi.jpg?v=1604553244"
              alt=""
            />
          </div>

          <div className={News.newsEmotion}>
            <PostEmotion />
          </div>

          <div className={News.feedAction}>
            <PostAction />
          </div>

          <div className={News.feedComment}>
            <PostComment />
            <div className={News.addComment}>
              <img
                src="https://scontent.fsgn5-6.fna.fbcdn.net/v/t39.30808-6/300376547_5491598224258453_7351247412124304056_n.jpg?stp=dst-jpg_s851x315&_nc_cat=108&ccb=1-7&_nc_sid=dbeb18&_nc_ohc=n6ZxL-YpVwMAX-9WE82&_nc_ht=scontent.fsgn5-6.fna&oh=00_AT-SZy5SSMfyG54liZf8KiXdOgajE2k_A994fgC35z0K6A&oe=63125470"
                alt=""
              />
              <input
                type="text"
                placeholder="Write a public comment"
                className={News.commentInput}
              />
            </div>
          </div>
        </div>
      </div>
    </React.Fragment>
  );
}

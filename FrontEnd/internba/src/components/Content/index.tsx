import React, { Fragment, useEffect, useState, useCallback } from "react";
import Card from "./Card.module.scss";
import News from "./News.module.scss";
import AddStatus from "../AddStatus";
import PostUser from "../PostUser";
import PostEmotion from "../PostEmotion";
import PostAction from "../PostAction";
import PostComment from "../PostComment";
import AddComment from "../AddComment";
import UpComment from "../PostComment";
import Modal from "../common/modal";
import UpdatePost from "../modal/updatepostmodal";
import AddPic from "../modal/attachModal";
import PostBody from "../PostBody";
export interface IPost {
  id: string;
  content: string;
  userId: string;
  attachment: string;
}
interface IAttach {
  id: string;
  image: string;
  video: string;
}

export default function Content(this: any, props: IPost) {
  const [show, setShow] = useState(false);
  const [posts, setPosts] = useState([]);

  const upPost = useCallback(() => {
    fetch("https://localhost:7076/api/Posts")
      .then((response) => response.json())
      .then((posts) => {
        console.log(posts);
        setPosts(posts);
      })
      .catch((err) => {
        ("");
        console.log(err.message);
      });
  }, []);
  useEffect(() => {
    upPost();
  }, [upPost]);

  //Delete
  const deletePost = (id: string) => {
    fetch(`https://localhost:7076/api/Posts?id=${id}`, {
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
  console.log(posts);

  return (
    <React.Fragment>
      <div style={{ width: "25%" }}>
        <div className={Card.newsCard}>
          <AddStatus upPost={upPost} />
        </div>

        <div className={Card.newsCard}>
          {posts.map((post: IPost) => {
            return (
              <React.Fragment>
                <PostBody
                  id={post.id}
                  content={post.content}
                  attachment={post.attachment}
                  userId={undefined}
                  upPost={upPost}
                  post={post}
                />
              </React.Fragment>
            );
          })}
        </div>
      </div>
    </React.Fragment>
  );
}

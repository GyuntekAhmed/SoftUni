const chai = require("chai");
const chaiHttp = require("chai-http");
const server = require("./server");

const expect = chai.expect;

chai.use(chaiHttp);

describe("Books API Tests", () => {
  let requestBody = {
    id: "1",
    title: "DevOps Magic 2",
    author: "Pesho",
  };

  it("should POST a book", (done) => {
    chai
      .request(server)
      .post("/books")
      .send(requestBody)
      .end((err, resp) => {
        if (err) {
          return done(err);
        }
        expect(resp.statusCode).to.be.equal(201);
        expect(resp.body).to.be.a("object");
        expect(resp.body.id).to.be.equal(requestBody.id);
        expect(resp.body.title).to.be.equal(requestBody.title);
        expect(resp.body.author).to.be.equal(requestBody.author);
        done();
      });
  });

  it("should GET all books", (done) => {
    chai
      .request(server)
      .get("/books")
      .end((err, resp) => {
        if (err) {
          return done(err);
        }
        expect(resp.statusCode, "Status code: ").to.equal(200);
        expect(resp.body).to.be.a("array");
        done();
      });
  });

  it("should GET a single book", (done) => {
    chai
      .request(server)
      .get("/books/1")
      .end((err, resp) => {
        if (err) {
          return done(err);
        }
        expect(resp.statusCode, "Status code: ").to.equal(200);
        expect(resp.body).to.be.a("object");
        expect(resp.body.id).to.exist;
        expect(resp.body.author).to.exist;
        expect(resp.body.title).to.exist;
        done();
      });
  });

  it("should UPDATE a book", (done) => {
    const reqBody = {
      id: "1",
      title: "DevOps Magic 2 Updated",
      author: "Gyuni",
    };
    chai
      .request(server)
      .put(`/books/${reqBody.id}`)
      .send(requestBody)
      .end((err, resp) => {
        if (err) {
          return done(err);
        }
        expect(resp.statusCode).to.be.equal(200);
        expect(resp.body).to.be.a("object");
        expect(resp.body.id).to.be.equal(requestBody.id);
        expect(resp.body.title).to.be.equal(requestBody.title);
        expect(resp.body.author).to.be.equal(requestBody.author);
        done();
      });
  });
});

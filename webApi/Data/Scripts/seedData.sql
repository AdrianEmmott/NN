-- seed data
delete from tags
delete from articleTags
delete from articles

declare @tags_salesParentId UNIQUEIDENTIFIER  
set @tags_salesParentId = '8eae1388-2dc2-40fa-b5a3-c205378de30c'

declare @tags_salesNew UNIQUEIDENTIFIER
set @tags_salesNew = '2fbe5769-a6a6-4b72-93ea-c25e1c7e6186'

declare @tags_marketingParentId UNIQUEIDENTIFIER  
set @tags_marketingParentId = '874983e8-bd5b-4438-a0a1-465e3c1ddf8c'

declare @tags_marketingNewParentId UNIQUEIDENTIFIER
set @tags_marketingNewParentId = '83969f00-c5a4-4c80-b913-4752b59008cf'

declare @article1Id UNIQUEIDENTIFIER
set @article1Id = 'a266a0b3-a4a7-4b7d-942b-35a67bc2a320'

declare @article2Id UNIQUEIDENTIFIER
set @article2Id = '43079781-12c1-4098-ac2d-f8b0272c3621'


-- TAGS
-- sales tag
insert into tags (id, title, parentId, showInNav, sortOrder) 
values (@tags_salesParentId, 'sales', null, 1, 1)

    insert into tags (id, title, parentid, showInNav, sortOrder) 
    values ('2fbe5769-a6a6-4b72-93ea-c25e1c7e6186', 'new', 
    @tags_salesParentId, 0, 1)

    insert into tags (id, title, parentid, showInNav, sortOrder) 
    values ('28433584-b1a3-41cd-bf3c-58d1f890b6b8', 'used', 
    @tags_salesParentId, 0, 2)

    insert into tags (id, title, parentid, showInNav, sortOrder) 
    values ('a8b4e3a3-6d8c-4d60-8f29-cedc071c3b85', 'fleet and business', 
    @tags_salesParentId, 0, 3)

    insert into tags (id, title, parentid, showInNav, sortOrder) 
    values ('394b7d51-0081-4606-ad09-f401ff64b38e', 'fleetboard', 
    @tags_salesParentId, 0, 4)


-- marketing
insert into tags (id, title, parentId, showInNav, sortOrder) 
values (@tags_marketingParentId, 'marketing', null, 1, 2)

    insert into tags (id, title, parentid, showInNav, sortOrder) 
    values (@tags_marketingNewParentId, 'new', @tags_marketingParentId, 0, 1)


        insert into tags (id, title, parentid, showInNav, sortOrder) 
        values ('951d93a2-e8d1-4de0-8422-d671940b5999', 
            'third level node 1', @tags_marketingNewParentId, 0, 1)


        insert into tags (id, title, parentid, showInNav, sortOrder) 
        values ('d74e1604-1971-4d06-bf8f-dbe17854ee96', 
            'third level node 2', @tags_marketingNewParentId, 0, 2)


    insert into tags (id, title, parentid, showInNav, sortOrder) 
    values ('e9545196-e491-4492-9ab1-8f0b4e60a7b4', 'used', 
        @tags_marketingParentId, 0, 2)

    insert into tags (id, title, parentid, showInNav, sortOrder) 
    values ('7876c4a0-e7a8-4313-9312-12431a717caf', 'new vans', 
        @tags_marketingParentId, 0, 3)

    insert into tags (id, title, parentid, showInNav, sortOrder) 
    values ('4b40c241-4706-484d-99c1-16ecd331fe95', 'used vans', 
        @tags_marketingParentId, 0, 4)

select * from tags


-- ARTICLES
insert into ARTICLES
(
    id,
    title,
    subTitle,
    summary,
    headerImage,
    content,
    author,
    published,
    publishDate,
    views
)
VALUES
(
    @article1Id,
    'New AMG GT coming Spring 2020!',
    'Lorem ipsum dolor sit amet feugiat',
    'Summary Lorem ipsum dolor sit amet feugiat',
    'http://localhost:8090/wwwroot/uploads/images/mercedes-amg-gt-s.jpg',
    '<p>Vestibulum scelerisque ultricies libero id hendrerit. Vivamus malesuada quam faucibus ante dignissim auctor hendrerit libero placerat. Nulla facilisi. Proin aliquam felis non arcu molestie at accumsan turpis commodo. Proin elementum, nibh non egestas sodales, augue quam aliquet est, id egestas diam justo adipiscing ante. Pellentesque tempus nulla non urna eleifend ut ultrices nisi faucibus.</p><p>Praesent a dolor leo. Duis in felis in tortor lobortis volutpat et pretium tellus. Vestibulum ac ante nisl, a elementum odio. Duis semper risus et lectus commodo fringilla. Maecenas sagittis convallis justo vel mattis. placerat, nunc diam iaculis massa, et aliquet nibh leo non nisl vitae porta lobortis, enim neque fringilla nunc, eget faucibus lacus sem quis nunc suspendisse nec lectus sit amet augue rutrum vulputate ut ut mi. Aenean elementum, mi sit amet porttitor lorem ipsum dolor sit amet, consectetur adipiscing elit. Lorem ipsum dolor sit amet nullam consequat feugiat dolore tempus.</p><h3>Something else</h3><p>Elementum odio duis semper risus et lectus commodo fringilla. Maecenas sagittis convallis justo vel mattis. placerat, nunc diam iaculis massa, et aliquet nibh leo non nisl vitae porta lobortis, enim neque fringilla nunc, eget faucibus lacus sem quis nunc suspendisse nec lectus sit amet augue rutrum vulputate ut ut mi. Aenean elementum, mi sit amet porttitor lorem ipsum dolor sit amet, consectetur adipiscing elit. Lorem ipsum dolor sit amet nullam consequat feugiat dolore tempus.</p><figure class=\"image\"><img src=\"http://localhost:8090/wwwroot/uploads/images/18c0638_003.jpg\"><figcaption>What a great looking car</figcaption></figure><p>Nunc diam iaculis massa, et aliquet nibh leo non nisl vitae porta lobortis, enim neque fringilla nunc, eget faucibus lacus sem quis nunc suspendisse nec lectus sit amet augue rutrum vulputate ut ut mi. Aenean elementum, mi sit amet porttitor lorem ipsum dolor sit amet, consectetur adipiscing elit. Lorem ipsum dolor sit amet nullam consequat feugiat dolore tempus.</p><h3>So in conclusion</h3><p>Nunc diam iaculis massa, et aliquet nibh leo non nisl vitae porta lobortis, enim neque fringilla nunc, eget faucibus lacus sem quis nunc suspendisse nec lectus sit amet augue rutrum vulputate ut ut mi. Aenean elementum, mi sit amet porttitor lorem ipsum dolor sit amet, consectetur adipiscing elit. Lorem ipsum dolor sit amet nullam consequat feugiat dolore tempus. Elementum odio duis semper risus et lectus commodo fringilla. Maecenas sagittis convallis justo vel mattis.</p>',
    'Adrian Emmott',
    0,
    '2019-09-10T23:00:00Z',
    0
)

insert into ARTICLES
(
    id,
    title,
    subTitle,
    summary,
    headerImage,
    content,
    author,
    published,
    publishDate,
    views
)
VALUES
(
    @article2Id,
    'Get a load of this guy!',
    'Lorem ipsum dolor sit amet feugiat',
    'Summary Lorem ipsum dolor sit amet feugiat',
    'http://localhost:8090/wwwroot/uploads/images/g63-4172.jpg',
    '<p>Vestibulum scelerisque ultricies libero id hendrerit. Vivamus malesuada quam faucibus ante dignissim auctor hendrerit libero placerat. Nulla facilisi. Proin aliquam felis non arcu molestie at accumsan turpis commodo. Proin elementum, nibh non egestas sodales, augue quam aliquet est, id egestas diam justo adipiscing ante. Pellentesque tempus nulla non urna eleifend ut ultrices nisi faucibus. Adrian Test 123</p><p>Praesent a dolor leo. Duis in felis in tortor lobortis volutpat et pretium tellus. Vestibulum ac ante nisl, a elementum odio. Duis semper risus et lectus commodo fringilla. Maecenas sagittis convallis justo vel mattis. placerat, nunc diam iaculis massa, et aliquet nibh leo non nisl vitae porta lobortis, enim neque fringilla nunc, eget faucibus lacus sem quis nunc suspendisse nec lectus sit amet augue rutrum vulputate ut ut mi. Aenean elementum, mi sit amet porttitor lorem ipsum dolor sit amet, consectetur adipiscing elit. Lorem ipsum dolor sit amet nullam consequat feugiat dolore tempus.</p><ol><li>Something</li><li>Something 2</li></ol><h3>Something else</h3><p>Elementum odio duis semper risus et lectus commodo fringilla. Maecenas sagittis convallis justo vel mattis. placerat, nunc diam iaculis massa, et aliquet nibh leo non nisl vitae porta lobortis, enim neque fringilla nunc, eget faucibus lacus sem quis nunc suspendisse nec lectus sit amet augue rutrum vulputate ut ut mi. Aenean elementum, mi sit amet porttitor lorem ipsum dolor sit amet, consectetur adipiscing elit. Lorem ipsum dolor sit amet nullam consequat feugiat dolore tempus.</p><blockquote><p>Nunc diam iaculis massa, et aliquet nibh leo non nisl vitae porta lobortis, enim neque fringilla nunc, eget faucibus lacus sem quis nunc suspendisse nec lectus sit amet augue rutrum vulputate ut ut mi. Aenean elementum, mi sit amet porttitor lorem ipsum dolor sit amet, consectetur adipiscing elit. Lorem ipsum dolor sit amet nullam consequat feugiat dolore tempus.</p></blockquote><h3>&nbsp;</h3><h3>So in conclusion</h3><figure class=\"image\"><img src=\"http://localhost:8090/wwwroot/uploads/images/07-mercedes-benz-vehicles-showcar-g-500-4x4-3400x1440.webp\"><figcaption>This is a 4x4 &nbsp;going off-road</figcaption></figure><p>&nbsp;diam iaculis massa, et aliquet nibh leo non nisl vitae porta lobortis, enim neque fringilla nunc, eget faucibus lacus sem quis nunc suspendisse nec lectus sit amet augue rutrum vulputate ut ut mi. Aenean elementum, mi sit amet porttitor lorem ipsum dolor sit amet, consectetur adipiscing elit. Lorem ipsum dolor sit amet nullam consequat feugiat dolore tempus. Elementum odio duis semper risus et lectus commodo fringilla. Maecenas sagittis convallis justo vel mattis.</p><p>&nbsp;</p>',
    'Adrian Emmott',
    0,
    '2019-09-21T21:52:00Z',
    0
)

select * from articles


-- ARTICLE TAGS
delete from articleTags

insert into articleTags
(
    articleId,
    tagId
)
VALUES
(
    @article1Id,
    @tags_salesParentId
)

insert into articleTags
(
    articleId,
    tagId
)
VALUES
(
    @article2Id,
    @tags_marketingNewParentId
)

insert into articleTags
(
    articleId,
    tagId
)
VALUES
(
    @article1Id,
    @tags_salesNew
)

select * from articleTags